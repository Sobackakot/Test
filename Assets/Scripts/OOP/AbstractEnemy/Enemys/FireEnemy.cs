 
using UnityEngine;

namespace EnemyAi
{
    [RequireComponent(typeof(Rigidbody))]
    public class FireEnemy : Enemy
    {
        private Transform trFireEnemy;
        private Rigidbody rbFireEnemy;
        [SerializeField]
        private GameObject bulletPrefab;
        public float speed = 6f;
        private void Awake()
        {
            trFireEnemy = GetComponent<Transform>();
            rbFireEnemy = GetComponent<Rigidbody>();
        }
        public override void Attack(Transform target)
        {
            GameObject newBullet = Instantiate(bulletPrefab, trFireEnemy.position, trFireEnemy.rotation);
            newBullet.transform.position = Vector3.MoveTowards(trFireEnemy.position, target.position, 15 * Time.deltaTime);

        }
        public override void FollowTarget(Transform target)
        {
            trFireEnemy.position = Vector3.MoveTowards(trFireEnemy.position, target.position, speed * Time.deltaTime);
        }

        public override void Move(Vector3 input)
        {
            rbFireEnemy.MovePosition(rbFireEnemy.position + input * speed * Time.fixedDeltaTime);
        }
    }
}


