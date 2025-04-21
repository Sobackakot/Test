
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
            var behaviour = new EnemyBehaviourHandler();

            InitializeBehaviours(behaviour, enemy);
            handler.SetState(new IdleEnemyState(behaviour.idle, behaviour.ranRot, behaviour.loockTar));

            handlersState[enemy] = handler;
            handlersBehaviour[enemy] = behaviour;
        }
    } 
    private void InitializeBehaviours(EnemyBehaviourHandler behaviour, Enemy enemy)
    { 
        behaviour.InitIdleBehaviour(new EnemyIdle(enemy));
        behaviour.InitMoveBehaviour(new EnemyMove(enemy));
        behaviour.InitRotateBehaviour(new EnemyRotate(enemy));
        behaviour.InitRandomMove(new EnemyRandomMove(enemy));
        behaviour.InitRandomRotate(new EnemyRandomRotate(enemy));
        behaviour.InitFollowTarget(new EnemyFollowTarget(enemy));
        behaviour.InitLoockTarget(new EnemyLoockTarget(enemy));
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
        var state = handlersState[enemy];
        var behaviour = handlersBehaviour[enemy];

        if (enemy.isFollowTarget)
            state.SetState(new FollowEnemyState(behaviour.followTar, behaviour.loockTar));
        else if (!enemy.isIdle && !enemy.isFollowTarget)
            state.SetState(new MoveEnemyState(behaviour.ranMove, behaviour.ranRot));
        else if (enemy.isIdle)
            state.SetState(new IdleEnemyState(behaviour.idle, behaviour.ranRot, behaviour.loockTar));
    }  
}
