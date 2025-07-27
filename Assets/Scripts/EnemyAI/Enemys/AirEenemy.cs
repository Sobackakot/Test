using EntityAI.Context;
using UnityEngine;

namespace EntityAI
{
    public class AirEenemy : EnemyBase
    {
        public override GameObject GetEntityPrefab()
        {
            return gameObject;
        }
    } 
}

