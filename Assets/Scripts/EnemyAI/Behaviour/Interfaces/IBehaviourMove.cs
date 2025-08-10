 
using UnityEngine;
namespace EntityAI.Behaviour
{ 
    public interface IBehaviourMove: IBehaviourBase
    { 
        void Moving(Vector3 targetMove);
    }
}