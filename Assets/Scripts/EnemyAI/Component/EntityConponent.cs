using UnityEngine;
using UnityEngine.AI;


namespace EntityAI.Components
{
    [RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))] 
    public class EntityConponent : MonoBehaviour , IEntityComponent
    { 
        private GameObject _prefab;
        public GameObject prefab => _prefab;


        private Transform _tr;
        public Transform tr => _tr;

         
        public Transform target { get ; set ; }

        Rigidbody _rb;
        public Rigidbody rb => _rb;

        NavMeshAgent _agent;
        public NavMeshAgent agent => _agent;
         

        private void Start()
        {
            _prefab = this.gameObject;
        
            _tr = transform;
            _rb = GetComponent<Rigidbody>();
            target = FindObjectOfType<TargetMove>().transform;
            _agent = GetComponent<NavMeshAgent>();
        }

    }
}