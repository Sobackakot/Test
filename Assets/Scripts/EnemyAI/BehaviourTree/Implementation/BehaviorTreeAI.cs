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

        // В инспекторе
        public float visionRadius = 15f;
        public float attackRange = 2f;
        public Vector3[] patrolPoints;

        void Start()
        {
            // Инициализация контекста
            //_context = new AIContext
            //{
            //    AITransform = transform,
            //    VisionRadius = visionRadius,
            //    AttackRange = attackRange,
            //    PatrolRange = 5f
            //};

            // Получаем зависимости
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
           // IRegistryTarget registry = FindObjectOfType<RegistryTarget>(); // Пример, лучше через DI
            //RaycastNPC raycast = GetComponent<RaycastNPC>(); // Пример, лучше через DI
           // INPCAction npcActions = GetComponent<INPCAction>(); // Пример

            // Сборка дерева поведения
            //_root = BuildTree(agent, registry, raycast, npcActions);
        }
        //private Node BuildTree(NavMeshAgent agent, IRegistryTarget registry, RaycastNPC raycast, INPCAction npcActions)
        //{
        //    // 1. Узел для атаки:
        //    //    Узел "Атаковать" будет выполнен только если цель в радиусе атаки.
        //    var attackBranch = new Sequence(
        //        new AttackRangeCondition(_context, new AttackNode(_context, npcActions)),
        //        new MoveToTargetNode(_context, agent)
        //    );

        //    // 2. Узел для преследования:
        //    //    Узел "Двигаться к цели" будет выполнен только если есть цель.
        //    var pursueBranch = new Sequence(
        //        new HasTargetCondition(_context, new MoveToTargetNode(_context, agent)),
        //        new AttackNode(_context, npcActions)
        //    );

        //    // 3. Главный селектор
        //    //    Выбираем, что делать в первую очередь:
        //    //    1. Если цель есть И мы в радиусе атаки, атакуем.
        //    //    2. Если цель есть, но мы далеко, преследуем.
        //    //    3. Если цели нет, ищем её.
        //    //    4. Если ничего не сработало, патрулируем.
        //    var root = new Selector(
        //        // Сначала пытаемся атаковать (самый высокий приоритет)
        //        new Sequence(
        //            new AttackRangeCondition(_context, new AttackNode(_context, npcActions)),
        //            new MoveToTargetNode(_context, agent) // Эта ветка не оптимальна, так как атакующий узел завершается успехом, а движение не будет выполнено
        //        ),

        //        // Затем пытаемся преследовать
        //        new Sequence(
        //            new HasTargetCondition(_context, new MoveToTargetNode(_context, agent))
        //        ),

        //        // Если ничего из этого не получилось - ищем цель
        //        new FindTargetNode(_context, registry, raycast),

        //        // Если и цель найти не удалось - патрулируем
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

