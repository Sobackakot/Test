using EntityAI.Repository;
using System.Collections.Generic;
using UnityEngine;

namespace EntityAI.Behaviour
{
    public class TargetSearchBehaviour : BehaviourBase
    {
        public TargetSearchBehaviour(IEntity entity, RaycastBehaviour ray) : base(entity)
        {
            this.ray = ray;
        }
        RaycastBehaviour ray;
        public void SearchNearbyTargets(Vector3 npcPosition, float visionRadius)
        {
            List<ITargetable> targets = entity.repTarSingl.GetTargets();
            foreach (var target in targets)
            {
                if (target != null && target.IsAlive() && IsMinRadius(npcPosition, target, visionRadius))
                {
                    if (IsEnemy(target.TargetType))
                    {
                        entity.repTarTrans.nearTargets.Add(target);
                    }
                }
            }
        }
        public void SearchDetectedTargets(Vector3 npcPosition, Vector3 npcDirection, float viewAngle)
        {
            foreach (var target in entity.repTarTrans.nearTargets)
            {
                if (IsMinAngle(target, npcPosition, npcDirection, viewAngle))
                {
                    entity.repTarTrans.detectedTargets.Add(target);
                }
            }
        }
        public void SearchRaycastHitTargets()
        {
            foreach (var target in entity.repTarTrans.detectedTargets)
            {
                if (target != null && ray.RaycastForward(target.targetTr.position))
                {
                    entity.repTarTrans.rayHitTargets.Add(target);
                }
            }
        }
        public void SearchBestTarget(Vector3 npcPosition)
        {
            float bestScore = float.MaxValue;
            ITargetable best = null;
            foreach (var target in entity.repTarTrans.rayHitTargets)
            {
                float score = Vector3.Distance(npcPosition, target.targetTr.position) + GetPriorityWeight(target.TargetType);
                if (score < bestScore)
                {
                    bestScore = score;
                    best = target;
                }
            }
            entity.repTarTrans.SetCurrentTarget(best);
        }
        private bool IsEnemy(TargetType targetType)
        {
            return targetType == TargetType.Enemy;
        }
        private bool IsMinAngle(ITargetable target, Vector3 npcPosition, Vector3 npcDirection, float viewAngle)
        {
            Vector3 direction = (target.targetTr.position - npcPosition).normalized;
            float angle = Vector3.Angle(npcDirection, direction);
            return angle < viewAngle / 2f;
        }
        private bool IsMinRadius(Vector3 npcPosition, ITargetable target, float visionRadius)
        {
            return Vector3.Distance(npcPosition, target.targetTr.position) <= visionRadius;
        }
        private float GetPriorityWeight(TargetType type)
        {
            return type switch
            {
                TargetType.Player => 5f,
                TargetType.Enemy => 10f,
                TargetType.Objective => 15f,
                _ => 20f
            };
        }

    }
}