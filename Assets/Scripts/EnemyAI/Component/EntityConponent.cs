using UnityEngine;
using UnityEngine.AI;


namespace EntityAI.Components
{
    [RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))] 
    public class EntityConponent : MonoBehaviour , IEntityComponent
    { 
        private GameObject _prefab;
        public GameObject prefab => _prefab;


        private Transform _trEntity;
        public Transform trEntity => _trEntity;

         
        public Transform trTarget { get ; set ; }

        Rigidbody _rbEntity;
        public Rigidbody rbEntity => _rbEntity;

        NavMeshAgent _agent;
        public NavMeshAgent agent => _agent;

        [SerializeField] Transform _raycastPoint;
        public Transform raycastPoint => _raycastPoint;

        private void Start()
        {
            _prefab = this.gameObject;

            _trEntity = GetComponent<Transform>();
            Debug.Log("init " + _trEntity.name);
            _rbEntity = GetComponent<Rigidbody>();
            trTarget = FindObjectOfType<TargetMove>().transform;
            _agent = GetComponent<NavMeshAgent>();
            _agent.updatePosition = true;
            _agent.updateRotation = true;
        }
      
    }
}