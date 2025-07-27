using EntityAI.Behaviour;
using EntityAI.Components;
using EntityAI.Config;
using EntityAI.Context;
using EntityAI.Planer;
using State.Machine;
using UnityEngine;

namespace EntityAI
{  
    public abstract class EnemyBase : MonoBehaviour , IEntity
    {

        private IContext _context;
        public IContext context => _context;


        private IEntityConfig _confige;
        public IEntityConfig config => _confige;


        private IEntityComponent _components;
        public IEntityComponent components => _components;


        private IBehaviourHandler _behaviourHandler;
        public IBehaviourHandler behaviourHandler => _behaviourHandler;


        private IStateMachine _stateMachine;
        public IStateMachine stateMachine => _stateMachine;


        private IPlaner<IContext> _planer;
        public IPlaner<IContext> planer => _planer;
         
    }
}


