using BehaviourFree.Node;

namespace BehaviourFree
{
    // DoNothingNode ����������� �� NodeBase
    public class DoNothingNode : NodeBase
    {
        // ����� Evaluate() � ��� ������������ ������ � ���� ����
        public override Status Evaluate()
        {
            // �� ������ ���������� Status.Success
            return Status.Success;
        }
    }
}