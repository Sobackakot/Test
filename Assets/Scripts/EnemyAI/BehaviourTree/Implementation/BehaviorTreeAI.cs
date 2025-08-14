using BehaviourFree.Node;
using EntityAI;
using EntityAI.Context;
using EntityAI.Repository;
using UnityEngine;


namespace BehaviourFree
{
    public class BehaviorTreeAI  
    {
        private NodeBase _rootNode;
        RaycastBehaviour ray;
        IContext ctx;
        IEntity entity;
        ITargetSingleRepository repository;
        public BehaviorTreeAI(IContext ctx, IEntity entity, ITargetSingleRepository repository)
        {
            this.ctx = ctx;
            this.entity = entity;
            this.repository = repository;
            ray = new RaycastBehaviour(entity);
            Enter();
        }
        public void Enter()
        {
            _rootNode = BuildTree();
        }
        private NodeBase BuildTree()
        { 
            var attackSequence = new SequenceNode(new AttackRangeCondition(ctx, new AttackTask(entity)));
             
            var chaseEnemySequence = new SequenceNode(
                new FindTargetNode(entity, ray, repository),
            new MoveToTargetTask(entity));
             
            var patrolTask = new PatrolTask(entity);
             
            _rootNode = new SelectorNode(
                attackSequence,
            chaseEnemySequence,
            patrolTask);

            return _rootNode;
        }
        public void Tick()
        { 
            _rootNode?.Evaluate();
        }
    }
}

