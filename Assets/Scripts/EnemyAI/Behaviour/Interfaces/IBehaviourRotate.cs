 
using UnityEngine;
namespace EntityAI.Behaviour
{ 
    public interface IBehaviourRotate: IBehaviourBase
    { 
        void Rotating(Quaternion targetRotation); 
    }
}