using System;
using UnityEngine;

namespace EnemyAI
{ 
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Enemy : MonoBehaviour 
    {
        [field: SerializeField] public EnemyStateContext context { get; private set; }
        public Transform target { get; private set; }
        public Rigidbody rb { get; private set; }
        public Transform tr { get; private set; }

        [field : Range(3, 30), SerializeField] public float minDistanceLoockTarget { get; private set; } = 30;
        [field: Range(3, 20), SerializeField] public float minDistanceFollowTarget { get; private set; } = 25;
        [field: Range(0.5f, 5), SerializeField] public float minDistanceAttackTarget { get; private set; } = 6;
        [field: Range(15, 45), SerializeField] public float minAngle { get; private set; } = 45f;
        [field: Range(60, 120), SerializeField] public float maxAngle { get; private set; } = 125f;
        [field: Range(3, 6), SerializeField] public float speedMove { get; private set; } = 5f;
        [field: Range(1, 45), SerializeField] public float angleRotate{ get; private set; } = 3f;

        public event Action onSpawn;

        private void OnEnable()
        {
            onSpawn?.Invoke();
        }
        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody>();
            tr = GetComponent<Transform>();
            target = FindObjectOfType<TargetMove>().transform; 
            context = new EnemyStateContext(this);
        }  
    } 
}


