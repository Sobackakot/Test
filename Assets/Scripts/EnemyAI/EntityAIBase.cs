using BehaviourFree;
using EntityAI.Behaviour;
using EntityAI.Components;
using EntityAI.Config;
using EntityAI.Context;
using EntityAI.Planer;
using EntityAI.React;
using EntityAI.Repository;
using State.Enemys;
using State.Machine;
using UnityEngine;

namespace EntityAI
{
    [RequireComponent(typeof(EntityConponent))]
    public abstract class EntityAIBase : MonoBehaviour, IEntity
    {
        ITargetSingleRepository _repTarSingl;
        public ITargetSingleRepository repTarSingl => _repTarSingl;
        BehaviorTreeAI tree;
        ITargetTransientRepository _repTarTrans;
        public ITargetTransientRepository repTarTrans => _repTarTrans;

        [SerializeField] private EntityConfige _config;
        public IEntityConfig config => _config;

        private IRepositorySubject _repositorySubject;
        public IRepositorySubject repositorySubject => _repositorySubject;


        private Context.EntityAI _context;
        public Context.EntityAI context => _context;
         

        private IEntityComponent _components;
        public IEntityComponent components => _components;


        private IBehaviourHandler _behaviourHandler;
        public IBehaviourHandler behaviourHandler => _behaviourHandler;


        private IStateMachine _stateMachine;
        public IStateMachine stateMachine => _stateMachine;


        private IPlaner<Context.EntityAI> _planer;
        public IPlaner<Context.EntityAI> planer => _planer;



        public void InitializeEntityAI(

            IRepositorySubject entityRepository,
            Context.EntityAI context, 
            IBehaviourHandler behaviourHandler,
            IStateMachine stateMachine,
            IPlaner<Context.EntityAI> planer)
        {
            _repositorySubject = entityRepository;
            _context = context; 
            _behaviourHandler = behaviourHandler;
            _stateMachine = stateMachine;
            _planer = planer;
            _repTarTrans = new TargetTransientRepository();
        }
        private void Awake()
        {
            _repTarSingl = FindObjectOfType<TargetSingleRepository>();
            _components = GetComponent<EntityConponent>(); 
        }
        private void Start()
        { 
            stateMachine?.SetState(StateType.Idle);
        }
        
        private void OnDisable()
        {
            Disposable();
        }
        public void Initializable()
        {
            repositorySubject?.InvokeAction(EntityActionType.EntityReg, config.entityId, this);
            planer?.SubscribeActions(context);
            tree = new BehaviorTreeAI(this); 
        }

        public void Disposable()
        {
            repositorySubject?.InvokeAction(EntityActionType.EntityUnreg, config.entityId, this);
            planer?.UnsubscribeActions(context);
        } 
        public void Tick()
        {
            stateMachine?.UpdateState();
            tree.Tick();
        }
        public void LateTick()
        {
            stateMachine?.LateUpdateState();
        }
        public void FixedTick()
        {
            stateMachine?.FixedUpdateState();
            planer?.UpdateContext(context);
        }
         
    }
}


