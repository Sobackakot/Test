 
using UnityEngine;
namespace EnemyAI
{ 
    public interface IEnemyRotate: IBehaviourHandler
    { 
        void Rotating(Quaternion targetRotation); 
    }
}