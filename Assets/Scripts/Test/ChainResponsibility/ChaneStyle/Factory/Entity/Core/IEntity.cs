using UnityEngine;  

namespace Entity
{
    public interface IEntity
    {
        EntityType entityType { get; }
        GameObject prefab { get; }
        Vector3 point { get; }
    }
    public enum EntityType
    {
        Fire,
        Freez,
        Ellectro
    }
}

