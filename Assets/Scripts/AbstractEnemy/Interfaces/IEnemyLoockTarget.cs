 
using UnityEngine;
namespace EnemyAi
{

    public interface IEnemyLoockTarget
    {
        bool isLoockTarget { get; set; }
        void LoockTarget();
    }
}