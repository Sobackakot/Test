
using EnemyAI;
using EnemyAI.Behaviour;
using EnemyAI.Context;
using EnemyAI.Plane;
using State.Enemys;
using State.Machine;
using System.Collections.Generic;
using UnityEngine; 

public class MainPoint : MonoBehaviour
{ 
    private List<Enemy> enemys = new();
    private Dictionary<Enemy, IStateMachine> stateMachines = new();
    private Dictionary<Enemy, IBehaviourHandler> behaviourHandlers = new(); 

    private Dictionary<Enemy, Planer<IContext>> planersAction = new(); 
     
    private void Awake()
    {
        enemys.AddRange(FindObjectsOfType<Enemy>());
    }
    private void OnEnable()
    {
        StartInit();
        foreach(var enemy in enemys)
            planersAction[enemy].SubscribeActions(enemy.context);
    }
    private void OnDisable()
    {
        foreach (var enemy in enemys)
            planersAction[enemy].UnsubscribeActions(enemy.context);
    } 
    private void StartInit()
    { 
        foreach (var enemy in enemys)
        {
            var stateMachine = new EnemyStateHandler();
            var behaviourHandler = new BehaviourHandler();
            var planerAction = new Planer<IContext>();
            
            InitBehaviours(enemy, behaviourHandler);
            InitStates(enemy,stateMachine, behaviourHandler);
            InitActions(planerAction, stateMachine); 

            behaviourHandlers[enemy] = behaviourHandler;
            stateMachines[enemy] = stateMachine;  
            planersAction[enemy] = planerAction;

            stateMachine.SetState(StateType.Idle);
        }
    }
    private void InitActions(Planer<IContext> planer, IStateMachine stateHandler)
    {
        planer.RegisterAction(new EnemyMoveAction(stateHandler));
    }
    private void InitBehaviours(Enemy enemy, IBehaviourHandler behHandler)
    {
        behHandler.RegisterBehaviour<IBehaviourIdle>(new EnemyIdle(enemy));

        behHandler.RegisterBehaviour<IBehaviourMove>(new EnemyMove(enemy));
        behHandler.RegisterBehaviour<IBehaviourRotate>(new EnemyRotate(enemy));

        behHandler.RegisterBehaviour<IBehaviourRandomMove>(new EnemyRandomMove(enemy));
        behHandler.RegisterBehaviour<IBehaviourRandomRotate>(new EnemyRandomRotate(enemy));

        behHandler.RegisterBehaviour<IBehaviourFollowTarget>(new EnemyFollowTarget(enemy));
        behHandler.RegisterBehaviour<IBehaviourLoockTarget>(new EnemyLoockTarget(enemy));
        
        behHandler.RegisterBehaviour<IBehaviourAttackTarget>(new EnemyAttackTarget(enemy));
    }
    public void InitStates(Enemy enemy, IStateMachine stateHandler, IBehaviourHandler behHandler)
    {
        stateHandler.RegisterState(StateType.Idle, new IdleEnemyState(enemy, stateHandler,behHandler));
        stateHandler.RegisterState(StateType.Move, new MoveEnemyState(enemy, stateHandler, behHandler));
        stateHandler.RegisterState(StateType.Follow, new FollowEnemyState(enemy, stateHandler, behHandler));
        stateHandler.RegisterState(StateType.Follow, new AttackEnemyState(enemy, stateHandler, behHandler));
    }
 
    
    private void Update()
    {
        foreach (var handler in stateMachines.Values)
            handler.UpdateState();
    }
    private void LateUpdate()
    {
        foreach (var handler in stateMachines.Values)
            handler.LateUpdateState();
    }
    private void FixedUpdate()
    { 
        foreach (var handler in stateMachines.Values)
            handler.FixedUpdateState();
        foreach (var enemy in enemys)
            planersAction[enemy].UpdateContext(enemy.context);
    }
}
