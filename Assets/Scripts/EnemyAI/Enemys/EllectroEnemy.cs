using UnityEngine;

namespace EnemyAI
{
    public class EllectroEnemy : EnemyBase
    {
        public override GameObject GetEntityPrefab()
        {
            return gameObject;
        }
    }
}

