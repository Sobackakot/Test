 
using UnityEngine;
namespace EnemyAi
{

    public interface IEnemyRandoMove
    {
        bool isRundomMove { get; set; }
        void RandomMove();

    }
}