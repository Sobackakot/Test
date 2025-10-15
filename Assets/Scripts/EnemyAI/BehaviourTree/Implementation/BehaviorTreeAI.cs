using BehaviourFree.Node;
using EntityAI;
using EntityAI.Behaviour;


namespace BehaviourFree
{
    public class BehaviorTreeAI  
    {
        public BehaviorTreeAI(IEntity entity)
        {
            this.entity = entity;
            ray = new RaycastBehaviour(entity);
            search = new TargetSearchBehaviour(entity, ray);
            Enter();
        }
        private NodeBase _rootNode;
        RaycastBehaviour ray;
        TargetSearchBehaviour search; 
        IEntity entity; 
     
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

            var notHasTarget = new Not(new HasTargetCondition(entity, new Success(entity)));

            var patrulSequence = new SequenceNode
            (
                notHasTarget,  
                new PatrolTask(entity)  
            ); 
             
            _rootNode = new SelectorNode(
                attackSequence,
                chaseEnemySequence,
                patrulSequence);

            return _rootNode;
        }
        public void Tick()
        { 
            _rootNode?.Evaluate();
        }
    }
}

