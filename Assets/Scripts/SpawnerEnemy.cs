using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    private List<Transform> points = new List<Transform>();
    private List<GameObject> enemys = new List<GameObject>();
    public GameObject enemyPrefab;
    private Vector3 point;
    private Quaternion direction;
    public int enemyAmount = 10;
    private void Awake()
    {
        points.AddRange(GetComponentsInChildren<Transform>());
    }
    private void Start()
    {
        for(int i =0; i < enemyAmount; i++)
        {
            Spawning();
        }
    }
    private void Spawning()
    {
        SetPoint();
       GameObject newEnemy = Instantiate(enemyPrefab, point, direction);
        enemys.Add(newEnemy);
    }
    private void SetPoint()
    {
        int index = Random.Range(0, points.Count);
        point = points[index].position;
        direction = points[index].rotation;
    }
    //Spawn enemies that were disabled after their hit points reached 0
    private void RespawnEnemy()
    {
        foreach(var enemy in enemys)
        {
            EnemyHP hp = enemy.GetComponent<EnemyHP>();
            if (hp.isDead)
            {
                hp.ResetEnemy();
                SetPoint();
                enemy.transform.position = point;
            }
        }
    }
    // call from  class EnemyH after the enemy was turned off
    public IEnumerator WaitTimeForSpawn()
    {
        yield return new WaitForSeconds(3);
        RespawnEnemy();
    }
}
