 
using UnityEngine;
namespace EntityAI
{ 
    public interface IBehaviourRotate: IBehaviourBase
    { 
        void Rotating(Quaternion targetRotation); 
    }
}