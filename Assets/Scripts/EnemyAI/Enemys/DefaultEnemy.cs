
using EnemyAI.Context;
using UnityEngine;


namespace EnemyAI
{
    public class DefaultEnemy : EnemyBase
    {
        public override GameObject GetEntityPrefab()
        {
            return gameObject;
        }
    }
}

