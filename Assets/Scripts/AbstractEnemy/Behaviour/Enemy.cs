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

        [Range(3, 30), SerializeField] public readonly float minDistanceLoockTarget = 30;
        [Range(3, 20), SerializeField] public readonly float minDistanceFollowTarget = 25;
        [Range(0.5f, 5), SerializeField] public readonly float minDistanceAttackTarget = 6;
        [Range(15, 45), SerializeField] public readonly float minAngle = 45f;
        [Range(60, 120), SerializeField] public readonly float maxAngle = 125f;
        [Range(3, 6), SerializeField] public readonly float speedMove = 5f;
        [Range(1, 45), SerializeField] public readonly float angleRotate = 3f;
         

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody>();
            tr = GetComponent<Transform>();
            target = FindObjectOfType<TargetMove>().transform; 
            context = new EnemyStateContext(this);
        }  
    } 
}


