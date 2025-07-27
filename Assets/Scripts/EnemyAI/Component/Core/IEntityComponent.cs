using UnityEngine;

namespace EntityAI.Components
{
    public interface IEntityComponent
    {
        GameObject prefab { get; }

        Transform tr { get; }

        Transform target { get; }

        Rigidbody rb { get; }
    }

}
