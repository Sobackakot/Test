using UnityEngine;

namespace EntityAI
{
    public class EllectroEnemy : EnemyBase
    {
        public override GameObject GetEntityPrefab()
        {
            return gameObject;
        }
    }
}

