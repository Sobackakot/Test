using EnemyAI.Context;
using UnityEngine;

namespace EnemyAI
{
    public class AirEenemy : EnemyBase
    {
        public override GameObject GetEntityPrefab()
        {
            return gameObject;
        }
    } 
}

