using EnemyAi; 
using System.Collections.Generic; 
using UnityEngine;
 
public class UserAccess : MonoBehaviour
{
    private List<Enemy> enemys = new List<Enemy>();
    private Dictionary<Enemy, EnemyStateHandler> handlers = new();
    private Dictionary<Enemy, EnemyBehaviourHandler> behaviours = new();

    private void Awake()
    {
        enemys.AddRange(FindObjectsOfType<Enemy>());
    }
    private void Start()
    { 
        foreach (var enemy in enemys)
        {
            var handler = new EnemyStateHandler();
            var behaviour = new EnemyBehaviourHandler(enemy);
            handler.SetState(new IdleEnemyState(behaviour.Idle, behaviour.Rotate, behaviour.Loock));
            handlers[enemy] = handler;
            behaviours[enemy] = behaviour;
        }
    }

    private void Update()
    {
        foreach (var enemy in enemys)
        { 
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
            handler.SetState(new AttackEnemyState(behaviours[enemy].Follow, behaviours[enemy].Loock, behaviours[enemy].Attack));
        }
        else if (enemy.isFollowTarget)
        {
            handler.SetState(new FollowEnemyState(behaviours[enemy].Follow, behaviours[enemy].Loock));
        }
        else if (!enemy.isIdle && !enemy.isFollowTarget)
        {
            handler.SetState(new MoveEnemyState(behaviours[enemy].RanMove, behaviours[enemy].RanRotate));
        }
        else if (enemy.isIdle)
        {
            handler.SetState(new IdleEnemyState(behaviours[enemy].Idle, behaviours[enemy].RanRotate, behaviours[enemy].Loock));
        }
    }

    
}
