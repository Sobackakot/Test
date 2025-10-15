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
            // Установка цели 
            entity.components.agent.SetDestination(entity.repTarTrans.currentTarget.targetTr.position);

            // Проверка условия остановки 
            if (entity.components.agent.remainingDistance <= entity.components.agent.stoppingDistance)
            {
                // тут будет логика остановки движения
                StoppedDestination();
                Debug.Log("success move");
                return Status.Success;
            }

            // тут будет логика продолжения движения
            Debug.Log("running move");
            return Status.Running;
        }
        public void StoppedDestination()
        {
            // Эту логику можно оставить, она обеспечивает дополнительную "мягкую" остановку.
            float distance = Vector3.Distance(entity.components.trEntity.position, entity.repTarTrans.currentTarget.targetTr.position);
            if (distance <= entity.components.agent.stoppingDistance * 1.5f) // Можно использовать stoppingDistance или немного больше
            {
                entity.components.agent.velocity = Vector3.zero;
            }
        }

    }
}