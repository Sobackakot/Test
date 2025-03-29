 
using UnityEngine;

namespace EnemyAi
{
    [RequireComponent(typeof(Rigidbody))]
    public class WoterEnemy : Enemy
    {
        private Transform trWoterEnemy;
        private Rigidbody rbWoterEnemy;
        [SerializeField]
        private GameObject bulletPrefab;
        public float speed = 8f;

        private void Awake()
        {
            trWoterEnemy = GetComponent<Transform>();
            rbWoterEnemy = GetComponent<Rigidbody>();
        }
        public override void Attack(Transform target)
        {
            GameObject newBullet = Instantiate(bulletPrefab, trWoterEnemy.position, trWoterEnemy.rotation);
            newBullet.transform.position = Vector3.MoveTowards(trWoterEnemy.position, target.position, 15 * Time.deltaTime);

        }
        public override void FollowTarget(Transform target)
        {
            trWoterEnemy.position = Vector3.MoveTowards(trWoterEnemy.position, target.position, speed * Time.deltaTime);
        }

        public override void Move(Vector3 input)
        {
            rbWoterEnemy.MovePosition(rbWoterEnemy.position + input * speed * Time.fixedDeltaTime);
        }
    }
}


