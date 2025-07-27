using UnityEngine;


namespace EntityAI.Components
{
    public class EntityConponent : MonoBehaviour , IEntityComponent
    {

        private GameObject _prefab;
        public GameObject prefab => _prefab;


        private Transform _tr;
        public Transform tr => _tr;


        Transform _target;
        public Transform target => _target;

        Rigidbody _rb;
        public Rigidbody rb => _rb;


        private void Awake()
        {
            _prefab = gameObject;
            _tr = transform;
            _rb = GetComponent<Rigidbody>();
            _target = FindObjectOfType<TargetMove>().transform;
        }

    }
}