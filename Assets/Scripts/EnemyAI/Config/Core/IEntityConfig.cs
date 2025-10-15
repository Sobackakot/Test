using System;
using System.Collections.Generic;
using UnityEngine;

namespace EntityAI.Config
{
    public interface IEntityConfig
    {
        float minDistanceInteract { get; }
        float maxDistanceRaycast { get; } 
        LayerMask targetLayer { get;} 
        LayerMask raycastLayers { get;}
        Vector3 spawnPoint { get; } 
        List<Transform> patrolPoints { get; }
        float time { get; }
        float timeAFC { get; set; }
        float interval { get;  } 

        EntityType entityType { get; }
         
         
        string entityId { get; }

        float minRadiusTrigger { get; }
        float visionRadius { get; }
        float viewAngle { get; }

        float minDistanceLoockTarget { get; }
         
        float minDistanceFollowTarget { get; } 
        float minDistanceAttackTarget { get; }

        float minAngleRotate { get; }
         
        float maxAngleRotate { get; }
         
        float speedMove { get; }
         
        float angleRotate { get; }

        void SetSpawnPoint(Vector3 point);
        void SetEntityId(string id);

        void SetPartolPoints(List<Transform> patrulPoints);
    }

}
