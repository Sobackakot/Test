 
using UnityEngine;
namespace EnemyAi
{ 
    public interface IEnemyFollowTarget: IBehaviourHandler
    { 
        void FollowTarget();
    }
}