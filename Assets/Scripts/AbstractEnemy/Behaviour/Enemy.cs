
using System;
using System.Collections; 
using UnityEngine; 
 
namespace EnemyAi
{ 
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Enemy : MonoBehaviour 
    {
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

        [field: Range(1, 45),SerializeField] public float timeAFC { get; private set; }=5f;

        public event Action OnExecuteMoveAction;
        [field: SerializeField] private bool _isIdle;
        public bool isIdle 
        { 
            get => _isIdle; 
            private set
            {
                if (_isIdle == value) return;
                _isIdle = value;
                OnExecuteMoveAction?.Invoke();
            } 
        }
        [field: SerializeField] private bool _isRandomMove; 
        public bool isRundomMove 
        {
            get => _isRandomMove; 
            private set
            {
                if (_isRandomMove == value) return;
                _isRandomMove = value;
                OnExecuteMoveAction?.Invoke();
            }
        }
        [field: SerializeField] private bool _isRandomRotate; 
        public bool isRandomRotate 
        {
            get => _isRandomRotate; 
            private set
            {
                if (_isRandomRotate == value) return;
                _isRandomRotate = value;
                OnExecuteMoveAction?.Invoke();
            }
        }


        [field: SerializeField] private bool _isFollowTarget; 
        public bool isFollowTarget 
        {
            get => _isFollowTarget; 
            private set
            {
                if (isFollowTarget == value) return;
                _isFollowTarget = value;
                OnExecuteMoveAction?.Invoke();
            }
        }
        [field: SerializeField] private bool _isLoockTarget; 
        public bool isLoockTarget 
        {
            get => _isFollowTarget;
            private set
            {
                if (_isFollowTarget == value) return;
                _isFollowTarget = value;
                OnExecuteMoveAction?.Invoke();
            } 
        }
        [field: SerializeField] private bool _isAttackTarget; 
        public bool isAttackTarget 
        {
            get => _isAttackTarget;
            private set
            {
                if (_isAttackTarget == value) return;
                _isAttackTarget = value;
                OnExecuteMoveAction?.Invoke();
            }
        }

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody>();
            tr = GetComponent<Transform>();
            target = FindObjectOfType<TargetMove>().transform; 
        } 
        private void Update()
        {
            TimerRoutine();
            isRundomMove = !isIdle && !isFollowTarget;
            isRandomRotate = !isLoockTarget;
            isLoockTarget = IsMinDistance(minDistanceLoockTarget);
            isAttackTarget = IsMinDistance(minDistanceAttackTarget);
            isFollowTarget = IsMinDistance(minDistanceFollowTarget);
        }  
        private bool IsMinDistance(float minDistance)
        {
            return Vector3.Distance(tr.position, target.position) <= minDistance;
        }
        private void TimerRoutine()
        {
            timeAFC -= Time.deltaTime;
            if (timeAFC <= 0)
            {
                timeAFC = UnityEngine.Random.Range(3f, 10f);
                if (!isFollowTarget)
                    StartCoroutine(IdleCoroutine());
            }
        } 
        private IEnumerator IdleCoroutine()
        {
            isIdle = true;
            yield return new WaitForSeconds(2.5f);
            isIdle = false;
        }
    } 
}


