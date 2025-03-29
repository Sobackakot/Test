 
using UnityEngine;

namespace EnemyAi
{
    public abstract class Enemy : MonoBehaviour
    { 
        public abstract void Move(Vector3 input);
        public abstract void FollowTarget(Transform target);
        public abstract void Attack(Transform target);
    } 
}


