using System;
using System.Collections.Generic;
using System.Linq;

// GOAPNode: Представляет одно строго типизированное состояние мира в графе поиска A*.
public class GOAPNode
{
    // Состояние мира теперь хранится как список строго типизированных фактов
     public Dictionary<Type, GOAPFact> WorldState { get; private set; }

    public GOAPNode Parent { get; private set; }
    public GOAPAction Action { get; private set; }
    public float RunningCost { get; private set; }

    // Конструктор
    public GOAPNode(Dictionary<Type, GOAPFact> parentState, GOAPNode parent, GOAPAction action, float cost)
    {
        // Клонируем состояние родителя (ВАЖНО! Клонируем и сами факты)
        WorldState = parentState.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Clone());

        Parent = parent;
        Action = action;
        RunningCost = cost;

        // Если есть действие, применяем его эффекты
        if (Action != null)
        {
            ApplyEffects(Action.GetEffects());
        }
    }
    public string GetStateKey()
    {
        // Сортировка по имени типа гарантирует, что порядок фактов всегда одинаков,
        // что необходимо для детерминированного ключа, независимо от порядка добавления фактов.
        return string.Join("|",
            WorldState
                .OrderBy(kv => kv.Key.FullName)
                .Select(kv => $"{kv.Key.FullName}:{kv.Value.GetValue()}"));
    }
    // Применение эффектов действия к состоянию узла
    private void ApplyEffects(Dictionary<Type, GOAPFact> effects)
    {
        foreach (var kvp in effects)
        {
            // Используем Type как ключ для добавления/замены
            WorldState[kvp.Key] = kvp.Value.Clone();
        }
    }
}