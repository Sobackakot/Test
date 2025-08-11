using BehaviourFree.Node;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;


namespace BehaviourFree
{
    public class BehaviorTreeAI : MonoBehaviour
    {
        //private Node _root;
        //private IContext _context;

        // � ����������
        public float visionRadius = 15f;
        public float attackRange = 2f;
        public Vector3[] patrolPoints;

        void Start()
        {
            // ������������� ���������
            //_context = new AIContext
            //{
            //    AITransform = transform,
            //    VisionRadius = visionRadius,
            //    AttackRange = attackRange,
            //    PatrolRange = 5f
            //};

            // �������� �����������
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
           // IRegistryTarget registry = FindObjectOfType<RegistryTarget>(); // ������, ����� ����� DI
            //RaycastNPC raycast = GetComponent<RaycastNPC>(); // ������, ����� ����� DI
           // INPCAction npcActions = GetComponent<INPCAction>(); // ������

            // ������ ������ ���������
            //_root = BuildTree(agent, registry, raycast, npcActions);
        }
        //private Node BuildTree(NavMeshAgent agent, IRegistryTarget registry, RaycastNPC raycast, INPCAction npcActions)
        //{
        //    // 1. ���� ��� �����:
        //    //    ���� "���������" ����� �������� ������ ���� ���� � ������� �����.
        //    var attackBranch = new Sequence(
        //        new AttackRangeCondition(_context, new AttackNode(_context, npcActions)),
        //        new MoveToTargetNode(_context, agent)
        //    );

        //    // 2. ���� ��� �������������:
        //    //    ���� "��������� � ����" ����� �������� ������ ���� ���� ����.
        //    var pursueBranch = new Sequence(
        //        new HasTargetCondition(_context, new MoveToTargetNode(_context, agent)),
        //        new AttackNode(_context, npcActions)
        //    );

        //    // 3. ������� ��������
        //    //    ��������, ��� ������ � ������ �������:
        //    //    1. ���� ���� ���� � �� � ������� �����, �������.
        //    //    2. ���� ���� ����, �� �� ������, ����������.
        //    //    3. ���� ���� ���, ���� �.
        //    //    4. ���� ������ �� ���������, �����������.
        //    var root = new Selector(
        //        // ������� �������� ��������� (����� ������� ���������)
        //        new Sequence(
        //            new AttackRangeCondition(_context, new AttackNode(_context, npcActions)),
        //            new MoveToTargetNode(_context, agent) // ��� ����� �� ����������, ��� ��� ��������� ���� ����������� �������, � �������� �� ����� ���������
        //        ),

        //        // ����� �������� ������������
        //        new Sequence(
        //            new HasTargetCondition(_context, new MoveToTargetNode(_context, agent))
        //        ),

        //        // ���� ������ �� ����� �� ���������� - ���� ����
        //        new FindTargetNode(_context, registry, raycast),

        //        // ���� � ���� ����� �� ������� - �����������
        //        new PatrolNode(_context, agent, patrolPoints)
        //    );

        //    return root;
        //}
        //void Update()
        //{
        //    _root?.Evaluate();
        //}
    }
}

