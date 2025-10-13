// GOAPPlanner: Теперь работает со списками GOAPFact
using System.Collections.Generic;
using System.Linq;

public  class GOAPPlanner
{
    private readonly IHeuristicStrategy _heuristicStrategy;
    private readonly IStateHasher _hasher;

    // Конструктор: Инжектируем вспомогательные стратегии (Strategy Pattern)
    public GOAPPlanner(IHeuristicStrategy heuristicStrategy, IStateHasher hasher)
    {
        _heuristicStrategy = heuristicStrategy;
        _hasher = hasher;
    }

    public List<IGOAPAction> Plan(IBlackboard startState, IGoapGoal goal,
                                 List<IGOAPAction> availableActions, int maxBudget = 5000)
    {
        var openList = new PriorityQueue<Node>();
        var closedList = new Dictionary<int, float>();

        var startNode = new Node(null, 0f, startState, null);
        openList.Enqueue(startNode, 0f);

        int budget = 0;

        while (openList.Count > 0 && budget < maxBudget)
        {
            var currentNode = openList.Dequeue();
            budget++;

            // 1. Проверка цели
            if (goal.IsSatisfied(currentNode.State)) return currentNode.GetActionPath();

            // 2. Хеширование состояния (через инжектированный сервис)
            int stateHash = _hasher.GetHash(currentNode.State);
            if (closedList.ContainsKey(stateHash) && currentNode.Cost >= closedList[stateHash]) continue;
            closedList[stateHash] = currentNode.Cost;

            // 3. Расширение узла
            foreach (var action in availableActions)
            {
                if (action.CheckPreconditions(currentNode.State))
                {
                    // Создание нового состояния через клонирование Blackboard (IBlackboard.Clone())
                    var nextState = currentNode.State.Clone();
                    action.ApplyEffects(nextState);

                    float newCost = currentNode.Cost + action.Cost;
                    var nextNode = new Node(currentNode, newCost, nextState, action);

                    // 4. Расчет эвристики (через инжектированный сервис)
                    float heuristicCost = _heuristicStrategy.Calculate(nextState, goal);
                    float totalCost = newCost + heuristicCost;

                    openList.Enqueue(nextNode, totalCost);
                }
            }
        }
        return null; // План не найден
    }
}

