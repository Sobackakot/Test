using BehaviourFree.Node;
using EntityAI;
using EntityAI.Behaviour;


namespace BehaviourFree
{
    public class BehaviorTreeAI  
    {
        private NodeBase _rootNode;
        RaycastBehaviour ray;
        TargetSearchBehaviour search; 
        IEntity entity; 
        public BehaviorTreeAI(IEntity entity)
        { 
            this.entity = entity; 
            ray = new RaycastBehaviour(entity);
            search = new TargetSearchBehaviour(entity, ray);
            Enter();
        }
        public void Enter()
        {
            _rootNode = BuildTree();
        }
        private NodeBase BuildTree()
        { 
            var attackSequence = new SequenceNode(
                    new HasTargetCondition(entity,
                        new AttackRangeCondition(entity, 
                            new AttackTask(entity))));
             
            var chaseEnemySequence = new SequenceNode(
                    new FindTargetNode(entity, search),
                    new HasTargetCondition(entity, 
                        new MoveToTargetTask(entity)));
             
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

