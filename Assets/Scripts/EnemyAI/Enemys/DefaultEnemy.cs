
using EntityAI.Context;
using UnityEngine;


namespace EntityAI
{
    public class DefaultEnemy : EnemyBase
    {
        public override GameObject GetEntityPrefab()
        {
            return gameObject;
        }
    }
}

