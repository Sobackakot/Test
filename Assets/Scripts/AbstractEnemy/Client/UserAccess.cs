
using System.Collections.Generic; 
using UnityEngine;
using EnemyAi.Behaviour; 
using EnemyAi;
using State.Enemys;

public class UserAccess : MonoBehaviour
{
    private List<Enemy> enemys = new List<Enemy>();
    private Dictionary<Enemy, EnemyStateHandler> handlersState = new();
    private Dictionary<Enemy, EnemyBehaviourHandler> handlersBehaviour = new(); 
    private void Awake()
    {
        enemys.AddRange(FindObjectsOfType<Enemy>());
    }
    private void OnEnable()
    {
        StartInit();
        foreach (var enemy in enemys)
        {
            SubscribeActions(enemy, handlersState[enemy]);
        }
    }
    private void OnDisable()
    {
        foreach(var enemy in enemys)
        {
            UnsubscribeActions(enemy, handlersState[enemy]);
        }
    }
    private void StartInit()
    { 
        foreach (var enemy in enemys)
        {
            var stateHandler = new EnemyStateHandler();
            var behaviours = new EnemyBehaviourHandler();

            InitializeBehaviours(behaviours, enemy);
            RegisterStates(stateHandler, behaviours, enemy);
            stateHandler.SetState(StateType.Idle);

            handlersState[enemy] = stateHandler;
            handlersBehaviour[enemy] = behaviours;
        }
    }
    private void InitializeBehaviours(EnemyBehaviourHandler behaviour, Enemy enemy)
    {
        behaviour.InitIdleBehaviour(new EnemyIdle(enemy));
        behaviour.InitRandomMove(new EnemyRandomMove(enemy));
        behaviour.InitRandomRotate(new EnemyRandomRotate(enemy));
        behaviour.InitFollowTarget(new EnemyFollowTarget(enemy));
        behaviour.InitLoockTarget(new EnemyLoockTarget(enemy));
        behaviour.InitAttackTarget(new EnemyAttackTarget(enemy));
    }
    public void RegisterStates(EnemyStateHandler stateHandler, EnemyBehaviourHandler behaviour, Enemy enemy)
    {
        stateHandler.RegisterState(StateType.Idle, new IdleEnemyState(stateHandler, behaviour.idle, enemy));
        stateHandler.RegisterState(StateType.Move, new MoveEnemyState(stateHandler, behaviour.ranMove, enemy));
        stateHandler.RegisterState(StateType.Follow, new FollowEnemyState(stateHandler, behaviour.followTar, enemy));
        stateHandler.RegisterState(StateType.Follow, new AttackEnemyState(stateHandler, behaviour.attack, enemy));
    }

    private void SubscribeActions(Enemy enemy, EnemyStateHandler stateHandler)
    {
        enemy.OnExecuteMoveAction += stateHandler.TryTransition; 
    }
    private void UnsubscribeActions(Enemy enemy, EnemyStateHandler stateHandler)
    {
        enemy.OnExecuteMoveAction -= stateHandler.TryTransition; 
    }
    
    private void Update()
    {
        foreach (var handler in handlersState.Values)
            handler.UpdateState();
    }
    private void LateUpdate()
    {
        foreach (var handler in handlersState.Values)
            handler.LateUpdateState();
    }
    private void FixedUpdate()
    {
        foreach (var handler in handlersState.Values)
            handler.FixedUpdateState();
    }
}
