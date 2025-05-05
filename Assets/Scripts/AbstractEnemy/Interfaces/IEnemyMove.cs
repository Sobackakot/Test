 
using UnityEngine;
namespace EnemyAi
{ 
    public interface IEnemyMove: IBehaviourHandler
    { 
        void Moving(Vector3 targetMove);
    }
}