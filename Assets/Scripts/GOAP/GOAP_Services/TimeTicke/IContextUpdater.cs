using System;
using System.Collections.Generic; 
// IContextUpdater: Контракт для изменения состояния мира (Blackboard) в реальном времени.
// Это отделяет логику изменения мира от самого GOAPAction.
public interface IContextUpdater
{
    // Имитирует течение времени. Обновляет состояние мира за заданный промежуток времени (deltaTime).
    // Должен обрабатывать:
    // - Износ инструмента (durability).
    // - Потребление энергии (EnergyDrainPerSec).
    // - Реакцию на критические состояния (например, автоматическое потребление запаса еды).
    void Tick(IBlackboard bb, Item toolUsed, float deltaTime);

    // Обновляет потребление голода/энергии вне действий (Idle).
    void TickIdle(IBlackboard bb, float deltaTime);
    void HandleFailureEffects(IBlackboard bb, Item toolUsed, float qualityPercentage);
}