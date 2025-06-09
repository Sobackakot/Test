
using EnemyAI;
using EnemyAI.Behaviour;
using EnemyAI.Plane;
using EnemyAI.Context;
using State.Enemys;
using System.Collections.Generic;
using UnityEngine;

public class UserAccess : MonoBehaviour
{
   
    private List<Enemy> enemys = new();
    private Dictionary<Enemy, EnemyStateHandler> handlersState = new();
    private Dictionary<Enemy, EnemyBehaviourHandler> handlersBehaviour = new();

    private Dictionary<Enemy, Planer<IContext>> planers = new(); 
     
    private void Awake()
    {
        enemys.AddRange(FindObjectsOfType<Enemy>());  
    }
    private void OnEnable()
    {
        StartInit();
        foreach(var enemy in enemys)
            planers[enemy].SubscribeActions(enemy.context);
    }
    private void OnDisable()
    {
        foreach (var enemy in enemys)
            planers[enemy].UnsubscribeActions(enemy.context);
    }
    private void StartInit()
    { 
        foreach (var enemy in enemys)
        {
            var stateHandler = new EnemyStateHandler();
            var behaviours = new EnemyBehaviourHandler();
            var planer = new Planer<IContext>();
            planer.AddAction(new EnemyMoveAction(stateHandler));
            InitializeBehaviours(behaviours, enemy);
            RegisterStates(stateHandler, behaviours, enemy);
            stateHandler.SetState(StateType.Idle);

            handlersState[enemy] = stateHandler;
            handlersBehaviour[enemy] = behaviours;
            planers[enemy] = planer;  
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
        foreach (var enemy in enemys)
            planers[enemy].UpdateContext(enemy.context);
    }
}
