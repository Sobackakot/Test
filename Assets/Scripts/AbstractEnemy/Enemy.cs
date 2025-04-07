
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
        [Range(15, 45), SerializeField] private float minAngle = 30f;
        [Range(60, 120), SerializeField] private float maxAngle = 120f;
        [Range(3, 6), SerializeField] private float speedMove = 5f;
        [Range(1, 45), SerializeField] private float angleRotate = 3f;
          
        
        protected Vector3 _targetMove;
        Vector3 IEnemyMove.TargetMove { get => _targetMove; set => _targetMove = value; }

        protected Quaternion _targetRotation;
        Quaternion IEnemyRotate.TargetRotation { get => _targetRotation; set => _targetRotation = value; }

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
                _targetRotation = Quaternion.Euler(0, newY, 0);
                Rotating(_targetRotation);
            }
        }

        public void FollowTarget()
        {
            if (!isIdle && isFollowTarget && !isAttackTarget)
            {
                _targetMove = (target.position - tr.position).normalized;
                Moving(_targetMove);
            }
        }

        public void LoockTarget()
        {
            if (isLoockTarget)
            {
                _targetMove = (target.position - tr.position).normalized;
                _targetRotation = Quaternion.LookRotation(new Vector3(_targetMove.x, 0, _targetMove.z));
                Rotating(_targetRotation);
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


