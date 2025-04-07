 
using UnityEngine;
namespace EnemyAi
{

    public interface IEnemyRotate
    {
        protected Quaternion targetRotation { get; set; }
        void Rotating(Quaternion targetRotation);
    }
}