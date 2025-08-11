using EntityAI;
using EntityAI.Repository;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourFree.Node
{
    public class FindTargetNode : NodeBase
    {
        ITargetSingleRepository repository;
        private readonly RaycastBehaviour _raycast;
        private readonly IEntity entity;
        public FindTargetNode(RaycastBehaviour raycast)
        { 
            _raycast = raycast;
        }

        public override Status Evaluate()
        {
            if (entity.context.isHasTarget) return Status.Failure;
            var position = entity.components.trEntity.position;
            SearchNearbyTargets(position, entity.config.visionRadius);
            SearchDetectedTargets(position, entity.config.directionTarget, entity.config.viewAngle);
            SearchRaycastHitTargets();
            SearchBestTarget(position);
            if (entity.repository.currentTarget == null)
            {
                entity.context.OnResetInteract();
                return Status.Running;
            } 
            else
            { 
                entity.context.OnSetInteract();
                return Status.Success;
            }
        }
        public void SearchNearbyTargets(Vector3 npcPosition, float visionRadius)
        {
            List<ITargetable> targets = repository?.GetTargets();
            foreach (var target in targets)
            {
                if (target != null && target.IsAlive() && IsMinRadius(npcPosition, target, visionRadius))
                {
                    if (entity.repository.nearTargets.Contains(target)) return;
                    if (IsEnemy(target.TargetType))
                    {
                        entity.repository.nearTargets.Add(target);
                    }

                }
            } 
        }
        public void SearchDetectedTargets(Vector3 npcPosition, Vector3 npcDirection, float viewAngle)
        {
            foreach (var target in entity.repository.nearTargets)
            {
                if (IsMinAngle(target, npcPosition, npcDirection, viewAngle))
                {
                    if (entity.repository.detectedTargets.Contains(target)) return;
                    entity.repository.detectedTargets.Add(target); 
                }
            }
            entity.repository.nearTargets.Clear();
        }
        public void SearchRaycastHitTargets()
        {
            foreach (var target in entity.repository.detectedTargets)
            {
                if (!entity.repository.rayHitTargets.Contains(target) && _raycast != null && _raycast.RaycastForward(target.targetTr.position))
                {
                    entity.repository.rayHitTargets.Add(target);  
                }
            }
            entity.repository.detectedTargets.Clear();
        }
        public void SearchBestTarget(Vector3 npcPosition)
        {
            float bestScore = float.MaxValue;
            ITargetable best = null;
            foreach (var target in entity.repository.rayHitTargets)
            {
                float score = Vector3.Distance(npcPosition, target.targetTr.position) + GetPriorityWeight(target.TargetType);
                if (score < bestScore)
                {
                    bestScore = score;
                    best = target;
                }
            }
            entity.repository.SetCurrentTarget(best);
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
