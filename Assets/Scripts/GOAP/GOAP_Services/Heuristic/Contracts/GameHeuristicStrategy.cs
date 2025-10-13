// GOAP.Services (Конкретная реализация)
public class GameHeuristicStrategy : IHeuristicStrategy
{
    public float Calculate(IBlackboard state, IGoapGoal goal)
    {
        // Вся логика, которая знает о EatGoal и HungerProperty, находится ЗДЕСЬ.
        if (goal is EatGoal)
        {
            if (state.TryGet<HungerProperty>(out var h))
            {
                // Эвристика: чем выше голод, тем меньше "нужно" действий (т.к. план простой).
                // Или чем ниже голод, тем выше эвристический штраф (для GOAP, это обычно штраф).
                return (100f - h.Value) * 0.1f; // Пример штрафа, зависящего от голода
            }
        }
        // ... другие конкретные цели ...

        return 0f; // Дефолтная эвристика (Dijkstra)
    }
}