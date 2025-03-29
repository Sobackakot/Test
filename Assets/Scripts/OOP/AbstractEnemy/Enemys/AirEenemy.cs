using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyAi
{
    public class AirEenemy : Enemy
    {
        public override void Attack(Transform target)
        {
            Debug.Log("atack");
        }

        public override void FollowTarget(Transform target)
        {
            Debug.Log("follow");
        }

        public override void Move(Vector3 input)
        {
            Debug.Log("move");
        }
    }

}

