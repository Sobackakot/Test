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
        ITargetSingleRepository _registry;
        public ITargetSingleRepository registry => _registry;
        BehaviorTreeAI tree;
        ITargetTransientRepository _repository;
        public ITargetTransientRepository repository => _repository;

        [SerializeField] private EntityConfige _config;
        public IEntityConfig config => _config;

        private IRepositorySubject _repositorySubject;
        public IRepositorySubject repositorySubject => _repositorySubject;


        private IContext _context;
        public IContext context => _context;
         

        private IEntityComponent _components;
        public IEntityComponent components => _components;


        private IBehaviourHandler _behaviourHandler;
        public IBehaviourHandler behaviourHandler => _behaviourHandler;


        private IStateMachine _stateMachine;
        public IStateMachine stateMachine => _stateMachine;


        private IPlaner<IContext> _planer;
        public IPlaner<IContext> planer => _planer;



        public void InitializeEntityAI(

            IRepositorySubject entityRepository,
            IContext context, 
            IBehaviourHandler behaviourHandler,
            IStateMachine stateMachine,
            IPlaner<IContext> planer)
        {
            _repositorySubject = entityRepository;
            _context = context; 
            _behaviourHandler = behaviourHandler;
            _stateMachine = stateMachine;
            _planer = planer;
            _repository = new TargetTransientRepository();
        }
        private void Awake()
        {
            _registry = FindObjectOfType<TargetSingleRepository>();
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
            tree = new BehaviorTreeAI(context, this, registry); 
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


