 
using UnityEngine;
namespace EnemyAi
{

    public interface IEnemyRotate
    {
        protected Quaternion TargetRotation { get; set; }
        void Rotating(Quaternion targetRotation); 
    }
}