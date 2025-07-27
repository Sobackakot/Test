using EntityAI.Context;
using UnityEngine;  

namespace Entity
{
    public interface IEntity
    {
        string entityId { get; }
        Vector3 spawnPoint { get; }
        Transform tr { get; }
        Transform target { get; }
        EntityType entityType { get; }
        IContext context { get; }
        Rigidbody rb { get; } 
        float angleRotate { get; }
        float minAngle { get; }
        float maxAngle { get; }
        float speedMove { get; }
        float minDistanceLoockTarget { get; }
        float minDistanceAttackTarget { get; }
        float minDistanceFollowTarget { get; }

        GameObject GetEntityPrefab();
        void SetSpawnPoint(Vector3 point);
    }
    public enum EntityType
    {
        Fire,
        Freez,
        Ellectro
    }
}

