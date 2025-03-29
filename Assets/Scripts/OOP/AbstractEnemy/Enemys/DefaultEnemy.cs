 
using UnityEngine;


namespace EnemyAi
{
    [RequireComponent(typeof(Rigidbody))]
    public class DefaultEnemy : Enemy
    {
        private Transform trDefaultEnemy;
        private Rigidbody rbDefaultEnemy;
        [SerializeField]
        private GameObject bulletPrefab;
        public float speed = 8f;

        private void Awake()
        {
            trDefaultEnemy = GetComponent<Transform>();
            rbDefaultEnemy = GetComponent<Rigidbody>();
        }
        public override void Attack(Transform target)
        {
            GameObject newBullet = Instantiate(bulletPrefab, trDefaultEnemy.position, trDefaultEnemy.rotation);
            newBullet.transform.position = Vector3.MoveTowards(trDefaultEnemy.position, target.position, 15 * Time.deltaTime);

        }
        public override void FollowTarget(Transform target)
        {
            trDefaultEnemy.position = Vector3.MoveTowards(trDefaultEnemy.position, target.position, speed * Time.deltaTime);
        }

        public override void Move(Vector3 input)
        {
            rbDefaultEnemy.MovePosition(rbDefaultEnemy.position + input * speed * Time.fixedDeltaTime);
        }
    }
}

