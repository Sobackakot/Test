using EnemyAi;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
 
public class UserAccess : MonoBehaviour
{
    private List<Enemy> enemys = new List<Enemy>();
    private Dictionary<Enemy, EnemyStateHandler> handlers = new();
     
     
    private float timer = 5;

    private void Awake()
    {
        enemys.AddRange(FindObjectsOfType<Enemy>()); 
    }
    private void Start()
    {
        foreach (var enemy in enemys)
        {
            var handler = new EnemyStateHandler();
            handler.SetState(new IdleEnemyState(enemy));
            handlers[enemy] = handler;
        }
    }
   
    void Update()
    {
        foreach (var enemy in enemys)
        {
            TimerAFC(enemy);
            ChengeState(enemy);
        }
    }
    private void FixedUpdate()
    {
        foreach (var handler in handlers.Values)
        {
            handler.UpdateState();
        }
    }
   
    private void ChengeState(Enemy currentEnemy)
    {
        var handler = handlers[currentEnemy];
        if (currentEnemy.isIdle)
            handler.SetState(new IdleEnemyState(currentEnemy));
        else if (!currentEnemy.isIdle && !currentEnemy.isFollowTarget)
            handler.SetState(new MoveEnemyState(currentEnemy)); 
        else if(currentEnemy.isFollowTarget)
            handler.SetState(new FollowEnemyState(currentEnemy));
        else if (currentEnemy.isAttackTarget)
            handler.SetState(new AttackEnemyState(currentEnemy));
    }
   
    private void TimerAFC(Enemy currentEnemy)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = Random.Range(3, 10);
            if (!currentEnemy.isFollowTarget)
                StartCoroutine(IdleWaitTime(currentEnemy));
        }
    }
    private IEnumerator IdleWaitTime(Enemy currentEnemy)
    {
        currentEnemy.isIdle = true;
        yield return new WaitForSeconds(2.5f);
        currentEnemy.isIdle = false;
    }
}
