using UnityEngine;

namespace EntityAI.Config
{
    public interface IEntityConfig
    {
        public EntityType entityType { get; }
         
        public Vector3 spawnPoint { get; }
         
        public string entityId { get; }
         
        public float minDistanceLoockTarget { get; }
         
        public float minDistanceFollowTarget { get; } 
        public float minDistanceAttackTarget { get; }
         
        public float minAngle { get; }
         
        public float maxAngle { get; }
         
        public float speedMove { get; }
         
        public float angleRotate { get; }

        void SetSpawnPoint(Vector3 point);
    }

}
