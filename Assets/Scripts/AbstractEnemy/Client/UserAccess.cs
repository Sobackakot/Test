
using System.Collections.Generic; 
using UnityEngine;
using EnemyAi.Behaviour;
using EnemyAi.State;
using EnemyAi;

public class UserAccess : MonoBehaviour
{
    private List<Enemy> enemys = new List<Enemy>();
    private Dictionary<Enemy, EnemyStateHandler> handlersState = new();
    private Dictionary<Enemy, EnemyBehaviourHandler> handlersBehaviour = new(); 
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
            handlersState[enemy] = handler;
            handlersBehaviour[enemy] = behaviour;
        }
    } 
    private void Update()
    {
        foreach (var enemy in enemys)
            ChangeState(enemy);
    } 
    private void FixedUpdate()
    {
        foreach (var handler in handlersState.Values)
            handler.UpdateState();
    } 
    private void ChangeState(Enemy enemy)
    {
        var handler = handlersState[enemy]; 
        if (enemy.isAttackTarget)
            handler.SetState(new AttackEnemyState(handlersBehaviour[enemy].Follow, handlersBehaviour[enemy].Loock, handlersBehaviour[enemy].Attack));
        else if (enemy.isFollowTarget)
            handler.SetState(new FollowEnemyState(handlersBehaviour[enemy].Follow, handlersBehaviour[enemy].Loock));
        else if (!enemy.isIdle && !enemy.isFollowTarget)
            handler.SetState(new MoveEnemyState(handlersBehaviour[enemy].RanMove, handlersBehaviour[enemy].RanRotate));
        else if (enemy.isIdle)
            handler.SetState(new IdleEnemyState(handlersBehaviour[enemy].Idle, handlersBehaviour[enemy].RanRotate, handlersBehaviour[enemy].Loock));
    }  
}
