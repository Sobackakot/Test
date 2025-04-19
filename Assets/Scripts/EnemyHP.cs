using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public bool isDead;
    public bool inActive;
    private SpawnerEnemy spawner;
    private void Awake()
    {
        spawner = FindObjectOfType<SpawnerEnemy>();
    }
    public void ResetEnemy()
    {
        inActive = false;
        isDead = false;
    } 
 
    public void Update()
    {
        if (inActive)
        {
            inActive = false;
            isDead = true;
            StartCoroutine(spawner.WaitTimeForSpawn()); 
        }
    } 
}
