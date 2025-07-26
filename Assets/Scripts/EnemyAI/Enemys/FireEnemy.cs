using UnityEngine;

namespace EnemyAI
{
    public class FireEnemy : EnemyBase
    {
        public override GameObject GetEntityPrefab()
        {
            return gameObject;
        }
    }
}


