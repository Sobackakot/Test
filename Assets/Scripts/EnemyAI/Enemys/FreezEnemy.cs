using UnityEngine;

namespace EnemyAI
{
    public class FreezEnemy : EnemyBase
    {
        public override GameObject GetEntityPrefab()
        {
            return gameObject;
        }
    }
}


