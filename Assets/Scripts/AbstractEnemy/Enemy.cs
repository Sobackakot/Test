
using System.Collections;
using UnityEngine; 
 
namespace EnemyAi
{ 
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Enemy : MonoBehaviour ,
        IEnemyIdle,
        IEnemyMove,
        IEnemyRotate,
        IEnemyRandoMove,
        IEnemyRandomRotate,
        IEnemyFollowTarget,
        IEnemyLoockTarget,
        IEnemyAttackTarget
    {
        protected Transform target;
        protected Rigidbody rb;
        protected Transform tr;

        [Range(3, 30), SerializeField] private float minDistanceLoockTarget = 30;
        [Range(3, 20), SerializeField] private float minDistanceFollowTarget = 25;
        [Range(0.5f, 5), SerializeField] private float minDistanceAttackTarget = 6;
        [Range(3, 8), SerializeField] private float timer = 5f;
        [Range(3, 8), SerializeField] private float waitIdle = 3f;
        [Range(15, 45), SerializeField] private float minAngle = 30f;
        [Range(60, 120), SerializeField] private float maxAngle = 120f;
        [Range(3, 6), SerializeField] private float speedMove = 5f;
        [Range(1, 45), SerializeField] private float angleRotate = 3f;
         
        Vector3 IEnemyMove.targetMove { get => TargetMove; set => TargetMove = value; }
        Quaternion IEnemyRotate.targetRotation { get => TargetRotation; set => TargetRotation = value; }

        protected Vector3 TargetMove;
        protected Quaternion TargetRotation;


        [field: SerializeField] public bool isIdle { get; set; }
        [field: SerializeField] public bool isRundomMove { get; set; }
        [field: SerializeField] public bool isRundomRotate { get; set; }
        [field: SerializeField] public bool isFollowTarget { get; set; }
        [field: SerializeField] public bool isLoockTarget { get; set; }
        [field: SerializeField] public bool isAttackTarget { get; set; }

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

        public void IdleState()
        {
            if (isIdle && !isRundomMove && !isFollowTarget)
            {
                Debug.Log("Idle state " + gameObject.name);
            }
        }

        public void Moving(Vector3 targetMove)
        {
            rb.MovePosition(rb.position + targetMove.normalized * speedMove * Time.fixedDeltaTime);
        }

        public void Rotating(Quaternion targetRotation)
        {
            Quaternion newRot = Quaternion.Slerp(tr.rotation, targetRotation, angleRotate * Time.fixedDeltaTime);
            rb.MoveRotation(newRot);
        }

        public void RandomMove()
        {
            if (!isIdle && isRundomMove && !isAttackTarget)
            {
                Moving(tr.forward);
            }
        }

        public void RandomRotate()
        {
            if (isRundomRotate)
            {
                float currentY = tr.eulerAngles.y;
                float turnAmount = Random.Range(minAngle, maxAngle);
                if (Random.value > 0.5f) turnAmount *= -1;
                float newY = currentY + turnAmount;
                TargetRotation = Quaternion.Euler(0, newY, 0);
                Rotating(TargetRotation);
            }
        }

        public void FollowTarget()
        {
            if (!isIdle && isFollowTarget && !isAttackTarget)
            {
                TargetMove = (target.position - tr.position).normalized;
                Moving(TargetMove);
            }
        }

        public void LoockTarget()
        {
            if (isLoockTarget)
            {
                TargetMove = (target.position - tr.position).normalized;
                TargetRotation = Quaternion.LookRotation(new Vector3(TargetMove.x, 0, TargetMove.z));
                Rotating(TargetRotation);
            }
        }

        public void AttackTarget()
        {
            if (isAttackTarget)
            {
                Debug.Log("Attack state " + gameObject.name);
            }
        }

        private bool IsMinDistance(float minDistance)
        {
            return Vector3.Distance(tr.position, target.position) <= minDistance;
        }
    } 
}


