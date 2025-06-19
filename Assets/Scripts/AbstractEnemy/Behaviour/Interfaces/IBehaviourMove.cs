 
using UnityEngine;
namespace EnemyAI
{ 
    public interface IBehaviourMove: IBehaviourBase
    { 
        void Moving(Vector3 targetMove);
    }
}