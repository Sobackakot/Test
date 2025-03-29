using EnemyAi;
using System.Collections.Generic;
using UnityEngine;
 
public class UserAccess : MonoBehaviour
{
    private List<Enemy> enemys = new List<Enemy>();
    private MainHandlerEnemyAi handler;
    private TargetMove target; 
    private Transform targetTr; 
    private Transform enemyTr;

    private int index;
    private bool isMinDistance; 

    private void Awake()
    {
        handler = new MainHandlerEnemyAi();
        target = FindObjectOfType<TargetMove>();
        targetTr = target.GetComponent<Transform>();
    }
    private void Start()
    { 
        enemys.AddRange(FindObjectsOfType<Enemy>()); 
    }
   
    void Update()
    {
        ChangeEnemy();
    }
    private void FixedUpdate()
    {
        if (enemyTr != null && index >= 0 && index < enemys.Count)
        {
            MoveEnemy();
        } 
    }
    private void ChangeEnemy()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index = Random.Range(0, enemys.Count);
            enemyTr = enemys[index].transform;
        }
    }
    private void MoveEnemy()
    {
        isMinDistance = handler.IsMinDistance(enemyTr, targetTr);
        if (isMinDistance)
            handler.FollowEnemy(enemys[index], targetTr);
        else handler.MoveEnemy(enemys[index], enemyTr);
    }
}
