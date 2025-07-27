 
using UnityEngine;
namespace EntityAI
{ 
    public interface IBehaviourMove: IBehaviourBase
    { 
        void Moving(Vector3 targetMove);
    }
}