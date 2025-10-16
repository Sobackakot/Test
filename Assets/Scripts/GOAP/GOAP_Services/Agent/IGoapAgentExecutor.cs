using EntityAI.GOAP.Action;
using EntityAI.GOAP.Goal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// IGoapAgentExecutor: Контракт для внешнего управления и инициализации агента GOAP.
public interface IGoapAgentExecutor
{
    // Методы для запуска и остановки цикла симуляции.
    void StartTicking();
    void StopTicking();

    // Метод для инициализации агента с его начальным состоянием, действиями и целями.
    // ЭТОТ МЕТОД ЗАМЕНЯЕТ СЛОЖНЫЙ КОНСТРУКТОР В МОНОБЕХЕЙВИОРАХ.
    void Initialize(IBlackboard initialState, List<IGOAPAction> actions, List<IGoapGoal> goals);
}