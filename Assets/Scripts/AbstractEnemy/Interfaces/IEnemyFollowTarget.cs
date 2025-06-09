 
using UnityEngine;
namespace EnemyAI
{ 
    public interface IEnemyFollowTarget: IBehaviourHandler
    { 
        void FollowTarget();
    }
}