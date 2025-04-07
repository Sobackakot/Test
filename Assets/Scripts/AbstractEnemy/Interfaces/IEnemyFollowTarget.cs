 
using UnityEngine;
namespace EnemyAi
{

    public interface IEnemyFollowTarget
    {
        bool isFollowTarget { get; set; }
        void FollowTarget();
    }
}