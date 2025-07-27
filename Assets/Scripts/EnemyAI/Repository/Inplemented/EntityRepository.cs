using EntityAI.Behaviour;
using EntityAI.Context;
using EntityAI.Planer;
using Entity;
using State.Enemys;
using State.Machine;
using System.Collections.Generic;

namespace EntityAI.Repository
{
    public class EntityRepository : IEntityRepository
    {

        Dictionary<string, IEntity> _entities = new();
        public Dictionary<string, IEntity>  entities => _entities;


        Dictionary<IEntity, IStateMachine> _stateMachines = new();
        public Dictionary<IEntity, IStateMachine> stateMachines => _stateMachines;


        Dictionary<IEntity, IBehaviourHandler> _behaviourHandlers = new();
        public Dictionary<IEntity, IBehaviourHandler> behaviourHandlers => _behaviourHandlers;


        Dictionary<IEntity, IPlaner<IContext>> _planersAction = new();
        public Dictionary<IEntity, IPlaner<IContext>> planersAction => _planersAction;



        public void RegistryEntity(string id, IEntity enemy)
        {
            if (!_entities.ContainsKey(id))
            {
                var fsm = new EnemyStateHandler();
                var behaviour = new BehaviourHandler();
                var planer = new Planer<IContext>(); 

                InitActions(planer, fsm);
                InitBehaviours(enemy, behaviour);
                InitStates(enemy, fsm , behaviour);

                _entities.Add(id, enemy);
                _stateMachines.Add(enemy, fsm);
                _behaviourHandlers.Add(enemy, behaviour);
                _planersAction.Add(enemy, planer);

                planersAction[enemy].SubscribeActions(enemy.context);
                fsm.SetState(StateType.Idle);
            }

        }

        public void UnRegistryEnemy(string id, IEntity enemy)
        {
            if (_entities.ContainsKey(id))
            {
                planersAction[enemy].UnsubscribeActions(enemy.context);
                _behaviourHandlers.Remove(enemy); 
                _stateMachines.Remove(enemy);
                _planersAction.Remove(enemy);
                _entities.Remove(id); 
            }
        }
         
        private void InitActions(IPlaner<IContext> planer, IStateMachine stateHandler)
        {
            planer.RegisterAction(new EnemyMoveAction(stateHandler));
        }
        private void InitBehaviours(IEntity enemy, IBehaviourHandler behHandler)
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
        public void InitStates(IEntity enemy, IStateMachine stateHandler, IBehaviourHandler behHandler)
        {
            stateHandler.RegisterState(StateType.Idle, new IdleEnemyState(enemy, stateHandler, behHandler));
            stateHandler.RegisterState(StateType.Move, new MoveEnemyState(enemy, stateHandler, behHandler));
            stateHandler.RegisterState(StateType.Follow, new FollowEnemyState(enemy, stateHandler, behHandler));
            stateHandler.RegisterState(StateType.Follow, new AttackEnemyState(enemy, stateHandler, behHandler));
        }

        public void Tick()
        {
            foreach(var state in stateMachines.Values)
            {
                state.UpdateState();
            }
        }

        public void LateTick()
        {
            foreach (var state in stateMachines.Values)
            {
                state.LateUpdateState();
            }
        }

        public void FixedTick()
        {
            foreach (var state in stateMachines.Values)
            {
                state.FixedUpdateState();
            }
            foreach (var entity in entities.Values)
            {
                planersAction[entity].UpdateContext(entity.context);
            }
        }

    }
}
