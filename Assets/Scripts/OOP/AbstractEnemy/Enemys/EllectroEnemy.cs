 
using UnityEngine;

namespace EnemyAi
{
    [RequireComponent(typeof(Rigidbody))]
    public class EllectroEnemy : Enemy
    {
        private Transform trEllecEnemy;
        private Rigidbody rbEllecEnemy;
        [SerializeField]
        private GameObject bulletPrefab;
        public float speed = 3f;
        private void Awake()
        {
            trEllecEnemy = GetComponent<Transform>();
            rbEllecEnemy = GetComponent<Rigidbody>();
        }

        public override void FollowTarget(Transform target)
        {
            trEllecEnemy.position = Vector3.MoveTowards(trEllecEnemy.position, target.position, speed * Time.deltaTime);
        }

        public override void Move(Vector3 input)
        {
            rbEllecEnemy.MovePosition(rbEllecEnemy.position + input * speed * Time.fixedDeltaTime);
        }

        public override void Attack(Transform target)
        {
            GameObject newBullet = Instantiate(bulletPrefab, trEllecEnemy.position, trEllecEnemy.rotation);
            newBullet.transform.position = Vector3.MoveTowards(trEllecEnemy.position, target.position, 15 * Time.deltaTime);
        }
    }
}

