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

        Transform _raycastPoint;
        public Transform raycastPoint => _raycastPoint;

        private void Start()
        {
            _prefab = this.gameObject;
        
            _trEntity = transform;
            _raycastPoint = transform;
            _rbEntity = GetComponent<Rigidbody>();
            trTarget = FindObjectOfType<TargetMove>().transform;
            _agent = GetComponent<NavMeshAgent>();
        }

    }
}