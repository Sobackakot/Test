using EntityAI.GOAP.WorldState;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHasher : IStateHasher
{
    // Список свойств, которые влияют на хеш и считаются "ключевыми"
    private readonly List<Type> _keyProperties = new List<Type>
    {
        typeof(HungerProperty),
        typeof(EnergyProperty),
        typeof(RawFoodProp),
        typeof(CookedFoodProp)
        // Добавьте сюда WoodProp, если его запас критически важен для планирования
    };

    public int GetHash(IBlackboard bb)
    {
        unchecked
        {
            int hash = 17;

            // Получаем доступ к внутренним свойствам для хеширования (для примера используем TryGet)

            foreach (var type in _keyProperties)
            {
                if (bb.TryGet<IWorldProperty>(out var prop) && prop.GetType() == type)
                {
                    // Используем GetValue(), чтобы получить хеш значения
                    hash = hash * 23 + prop.GetValue().GetHashCode();
                }
            }

            // Включаем хеш инвентаря
            hash = hash * 23 + bb.Inventory.GetItemsHash();
            return hash;
        }
    }
 
}
