using EntityAI.Behaviour;
using UnityEngine;

namespace EntityAI
{
    public class EnemyMove : BehaviourBase 
    {
        public EnemyMove(IEntity entity) : base(entity)
        { 
        }

        public override void Moving(Vector3 targetMove)
        {
            entity.components.agent.SetDestination(targetMove);
        }
    }
}