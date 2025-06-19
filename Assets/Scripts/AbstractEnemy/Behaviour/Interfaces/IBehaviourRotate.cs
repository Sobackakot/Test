 
using UnityEngine;
namespace EnemyAI
{ 
    public interface IBehaviourRotate: IBehaviourBase
    { 
        void Rotating(Quaternion targetRotation); 
    }
}