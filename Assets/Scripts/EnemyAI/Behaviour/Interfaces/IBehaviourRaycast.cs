using UnityEngine;

namespace EntityAI.Behaviour
{
    public interface IBehaviourRaycast : IBehaviourBase
    {
        bool RaycastForward(Vector3 targetPos);
    }
}