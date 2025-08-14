using EntityAI;
using UnityEngine;

namespace BehaviourFree.Node
{
    public class MoveToTargetTask : NodeBase
    { 
        private readonly IEntity entity; 

        public MoveToTargetTask(IEntity entity)
        {
            this.entity = entity;
        }

        public override Status Evaluate()
        {
            // 1. Проверяем, что цель существует
            if (entity.repository.currentTarget == null)
            {
                return Status.Failure; // Задача провалена
            }

            // 2. Устанавливаем цель движения

            Debug.Log("moveTarget " + entity.repository.currentTarget);
            entity.components.agent.SetDestination(entity.repository.currentTarget.targetTr.position);
            StoppedDestination();

            // 3. Проверяем, достигнута ли цель
            if (entity.components.agent.remainingDistance <= entity.components.agent.stoppingDistance)
            {
                return Status.Success; // Задача выполнена
            }
            else
            {
                return Status.Running; // Задача ещё в процессе
            } 
        }
        public void StoppedDestination()
        {
            float distance = Vector3.Distance(entity.components.trEntity.position, entity.repository.currentTarget.targetTr.position);
            if (distance <= 2)
            {
                entity.components.agent.velocity = Vector3.zero;
                ResetFocus();
            }
        }
     
        public void ResetFocus()
        {
            entity.context.OnResetInteract();
            entity.repository.SetCurrentTarget(null); 
        }
    }
}