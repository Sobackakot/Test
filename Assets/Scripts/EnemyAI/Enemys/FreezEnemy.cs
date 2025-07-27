using UnityEngine;

namespace EntityAI
{
    public class FreezEnemy : EnemyBase
    {
        public override GameObject GetEntityPrefab()
        {
            return gameObject;
        }
    }
}


