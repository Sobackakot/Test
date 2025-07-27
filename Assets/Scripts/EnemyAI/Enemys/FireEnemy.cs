using UnityEngine;

namespace EntityAI
{
    public class FireEnemy : EnemyBase
    {
        public override GameObject GetEntityPrefab()
        {
            return gameObject;
        }
    }
}


