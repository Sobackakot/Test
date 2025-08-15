using EntityAI.Behaviour;
using EntityAI;
using UnityEngine;

namespace EntityAI
{
    public class EnemyRotate : BehaviourBase
    {
        public EnemyRotate(IEntity enemy) : base(enemy)
        { 
        }

        public override void Rotating(Quaternion targetRotation)
        {
            //Quaternion newRot = Quaternion.Slerp(entity.components.trEntity.rotation, targetRotation, entity.config.angleRotate * Time.fixedDeltaTime);
            //entity.components.rbEntity.MoveRotation(newRot);
        }
    }
}