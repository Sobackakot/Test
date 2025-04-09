
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
        [Range(15, 45), SerializeField] public readonly float minAngle = 30f;
        [Range(60, 120), SerializeField] public readonly float maxAngle = 120f;
        [Range(3, 6), SerializeField] public readonly float speedMove = 5f;
        [Range(1, 45), SerializeField] public readonly float angleRotate = 3f;

        [field: Range(1, 45),SerializeField] public float timeAFC { get; private set; }=5f;  
        [field: SerializeField] public bool isIdle { get; private set; }
        [field: SerializeField] public bool isRundomMove { get; private set; }
        [field: SerializeField] public bool isRundomRotate { get; private set; }
        [field: SerializeField] public bool isFollowTarget { get; private set; }
        [field: SerializeField] public bool isLoockTarget { get; private set; }
        [field: SerializeField] public bool isAttackTarget { get; private set; }

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
            isRundomRotate = !isLoockTarget;
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
                timeAFC = Random.Range(3f, 10f);
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


