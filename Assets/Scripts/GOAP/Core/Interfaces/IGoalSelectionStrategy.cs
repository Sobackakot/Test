using System.Collections.Generic;
using System;

// IGoalSelectionStrategy: Интерфейс для инверсии зависимости.
public interface IGoalSelectionStrategy
{
    // Метод принимает все цели и текущее состояние мира, возвращает лучшую.
    GOAPGoal SelectBestGoal(List<GOAPGoal> allGoals, Dictionary<Type, GOAPFact> worldState);
}