using UnityEngine;
using UnityEngine.AI;

namespace EntityAI.Components
{
    public interface IEntityComponent
    {
        NavMeshAgent agent { get; }
        GameObject prefab { get; }

        Transform tr { get; }

        Transform target { get; set; }

        Rigidbody rb { get; }
    }

}
