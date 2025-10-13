// Blackboard: Центральное хранилище состояния мира и инвентаря.
using System;
using System.Collections.Generic;
using System.Linq;

public class Blackboard : IBlackboard
{
    // Словарь для хранения всех свойств мира (фактов) по их типу.
    internal readonly Dictionary<Type, IWorldProperty> _props = new Dictionary<Type, IWorldProperty>();

    // Инвентарь (заимствованная модель).
    public Inventory Inventory = new Inventory();

    IInventory IBlackboard.Inventory => Inventory;

    // Регистрирует новое свойство в Blackboard.
    public void Register(IWorldProperty p) => _props[p.GetType()] = p;

    // Пытается получить свойство по его типу.
    public bool TryGet<T>(out T p) where T : class, IWorldProperty
    {
        if (_props.TryGetValue(typeof(T), out var v))
        {
            p = v as T;
            return true;
        }
        p = null;
        return false;
    }

    // Ключевой метод для GOAP: создает глубокую копию для симуляции.
    public IBlackboard Clone()
    {
        var nb = new Blackboard();
        foreach (var kv in _props)
            nb._props[kv.Key] = kv.Value.Clone();
        nb.Inventory = this.Inventory.DeepCopy();
        return nb;
    }

    // Удобный метод для отладки.
    public string DebugDump()
    {
        var parts = _props.OrderBy(p => p.Key.Name).Select(kv => $"{kv.Key.Name}={kv.Value.GetValue()}").ToList();
        parts.Add($"Inventory=[{Inventory}]");
        return string.Join(" | ", parts);
    }

 
}