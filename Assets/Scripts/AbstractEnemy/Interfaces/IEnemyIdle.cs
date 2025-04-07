 
using UnityEngine;
namespace EnemyAi
{

    public interface IEnemyIdle
    {
        bool isIdle { get; set; }
        void IdleState();
    }
}