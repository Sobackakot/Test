using EnemyAi;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
 
public class UserAccess : MonoBehaviour
{
    private List<Enemy> enemies = new();
    private Dictionary<Enemy, EnemyStateHandler> handlers = new();
    private float timer = 5f;

    private void Awake()
    {
        enemies.AddRange(FindObjectsOfType<Enemy>());
    }

    private void Start()
    {
        foreach (var enemy in enemies)
        {
            var handler = new EnemyStateHandler();
            handler.SetState(new IdleEnemyState(enemy, enemy, enemy));
            handlers[enemy] = handler;
        }
    }

    private void Update()
    {
        foreach (var enemy in enemies)
        {
            TimerRoutine(enemy);
            ChangeState(enemy);
        }
    }

    private void FixedUpdate()
    {
        foreach (var handler in handlers.Values)
        {
            handler.UpdateState();
        }
    }

    private void ChangeState(Enemy enemy)
    {
        var handler = handlers[enemy];

        if (enemy.isAttackTarget)
        {
            handler.SetState(new AttackEnemyState(enemy, enemy, enemy));
        }
        else if (enemy.isFollowTarget)
        {
            handler.SetState(new FollowEnemyState(enemy, enemy));
        }
        else if (!enemy.isIdle && !enemy.isFollowTarget)
        {
            handler.SetState(new MoveEnemyState(enemy, enemy));
        }
        else if (enemy.isIdle)
        {
            handler.SetState(new IdleEnemyState(enemy, enemy, enemy));
        }
    }

    private void TimerRoutine(Enemy enemy)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = Random.Range(3f, 10f);
            if (!enemy.isFollowTarget)
                StartCoroutine(IdleCoroutine(enemy));
        }
    }

    private IEnumerator IdleCoroutine(Enemy enemy)
    {
        enemy.isIdle = true;
        yield return new WaitForSeconds(2.5f);
        enemy.isIdle = false;
    }
}
