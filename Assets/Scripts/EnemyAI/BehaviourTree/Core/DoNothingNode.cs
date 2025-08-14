using BehaviourFree.Node;

namespace BehaviourFree
{
    // DoNothingNode наследуется от NodeBase
    public class DoNothingNode : NodeBase
    {
        // Метод Evaluate() — это единственная логика в этом узле
        public override Status Evaluate()
        {
            // Он просто возвращает Status.Success
            return Status.Success;
        }
    }
}