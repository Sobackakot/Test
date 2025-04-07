 
using UnityEngine;
namespace EnemyAi
{

    public interface IEnemyRandomRotate
    {
        bool isRundomRotate { get; set; }
        void RandomRotate();
    }
}