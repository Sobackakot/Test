
using System.Collections;
using UnityEngine;

namespace EnemyAi
{ 
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Enemy : MonoBehaviour
    {
        protected Transform target;
        protected Rigidbody rb;
        protected Transform tr;

        [Range(3, 30), SerializeField] protected float minDistanceLoockTarget = 30;
        [Range(3, 20), SerializeField] protected float minDistanceFollowTarget = 25;
        [Range(0.5f, 5), SerializeField] protected float minDistanceAttackTarget = 6;
        [Range(3, 8), SerializeField] protected float timer = 5f;
        [Range(3, 8), SerializeField] protected float waitIdle = 3f;
        [Range(15, 45), SerializeField] protected float minAngle = 30f;
        [Range(60, 120), SerializeField] protected float maxAngle = 120f;
        [Range(3, 6), SerializeField] protected float speedMove = 5f;
        [Range(1, 45), SerializeField] protected float angleRotate = 3f;

        protected Vector3 targetMove;
         
        [field: SerializeField] public bool isLoockTarget { get; set; }
        [field: SerializeField] public bool isFollowTarget { get; set; }
        [field: SerializeField] public bool isAttackTarget { get; set; }
        [field: SerializeField] public bool isIdle { get; set; }
        [field: SerializeField] public bool isRundomMove { get; set; }
        [field: SerializeField] public bool isRundomRotate { get; set; }

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody>();
            tr = GetComponent<Transform>();
            target = FindObjectOfType<TargetMove>().transform;
        }

        private void Update()
        {
            isRundomMove = !isIdle && !isFollowTarget;
            isRundomRotate = !isLoockTarget;
            isLoockTarget = IsMinDistance(minDistanceLoockTarget);
            isAttackTarget = IsMinDistance(minDistanceAttackTarget);
            isFollowTarget = IsMinDistance(minDistanceFollowTarget); 
        }
        
        public void AttackState()
        {
            if (isAttackTarget)
            {
                Debug.Log("attac state " + gameObject.name); 
            }
        }
        public void IdleState()
        {
            if (isIdle && !isRundomMove && !isFollowTarget)
            {
                Debug.Log("Idle state " + gameObject.name); 
            }
        }

        public virtual void TargetMoveState()
        {
            if (!isIdle && isFollowTarget  && !isAttackTarget)
                Moving(targetMove);
        }

        public virtual void TargetRotateState()
        {
            if (isLoockTarget)
            {
                targetMove = (target.position - tr.position).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(new Vector3(targetMove.x, 0, targetMove.z));
                Rotating(targetRotation);
            }
        }

        public virtual void RandomMoveState()
        {
            if (!isIdle && isRundomMove && !isAttackTarget)
                Moving(tr.forward);
        }

        public virtual void RandomRotateState()
        {
            if (isRundomRotate)
            {
                float currentY = tr.eulerAngles.y;
                float turnAmount = Random.Range(minAngle, maxAngle);
                if (Random.value > 0.5f) turnAmount *= -1;
                float newY = currentY + turnAmount;
                Quaternion targetRotation = Quaternion.Euler(0, newY, 0);
                Rotating(targetRotation);
            }
        }

        protected virtual void Rotating(Quaternion targetRotation)
        {
            Quaternion newRot = Quaternion.Slerp(tr.rotation, targetRotation, angleRotate * Time.fixedDeltaTime);
            rb.MoveRotation(newRot);
        }

        protected virtual void Moving(Vector3 targetMove)
        {
            rb.MovePosition(rb.position + targetMove.normalized * speedMove * Time.fixedDeltaTime);
        }

        protected bool IsMinDistance(float MinDistance)
        {
            return Vector3.Distance(tr.position, target.position) <= MinDistance;
        }
    } 
}


