// GOAP.Core.Interfaces
public interface IHeuristicStrategy
{
    // Метод принимает абстрактное состояние (IBlackboard) и абстрактную цель (IGoapGoal).
    // Он знает, как вычислить эвристику для этой конкретной комбинации.
    float Calculate(IBlackboard state, IGoapGoal goal);
}