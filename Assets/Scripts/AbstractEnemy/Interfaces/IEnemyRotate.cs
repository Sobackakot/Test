 
using UnityEngine;
namespace EnemyAi
{ 
    public interface IEnemyRotate: IBehaviourHandler
    { 
        void Rotating(Quaternion targetRotation); 
    }
}