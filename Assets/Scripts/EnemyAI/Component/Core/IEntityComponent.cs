using UnityEngine;
using UnityEngine.AI;

namespace EntityAI.Components
{
    public interface IEntityComponent
    { 
        NavMeshAgent agent { get; }
        GameObject prefab { get; }

        Transform trEntity { get; }

        Transform raycastPoint { get; }

        Transform trTarget { get; set; }

        Rigidbody rbEntity { get; }
    }

}
