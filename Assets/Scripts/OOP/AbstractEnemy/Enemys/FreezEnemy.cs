 
using UnityEngine;

namespace EnemyAi
{
    [RequireComponent(typeof(Rigidbody))]
    public class FreezEnemy : Enemy
    {
        private Transform trFreezEnemy;
        private Rigidbody rbFreezEnemy;
        [SerializeField]
        private GameObject bulletPrefab;
        public float speed = 4f;

        private void Awake()
        {
            trFreezEnemy = GetComponent<Transform>();
            rbFreezEnemy = GetComponent<Rigidbody>();
        }
        public override void Attack(Transform target)
        {
            GameObject newBullet = Instantiate(bulletPrefab, trFreezEnemy.position, trFreezEnemy.rotation);
            newBullet.transform.position = Vector3.MoveTowards(trFreezEnemy.position, target.position, 15 * Time.deltaTime);

        }
        public override void FollowTarget(Transform target)
        {
            trFreezEnemy.position = Vector3.MoveTowards(trFreezEnemy.position, target.position, speed * Time.deltaTime);
        }

        public override void Move(Vector3 input)
        {
            rbFreezEnemy.MovePosition(rbFreezEnemy.position + input * speed * Time.fixedDeltaTime);
        }
    }
}


