using EntityAI.GOAP.WorldState;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IBlackboard
{
    // Доступ к свойствам мира
    bool TryGet<T>(out T p) where T : class, IWorldProperty;

    // Доступ к инвентарю (Остается как модель данных для клонирования)
    IInventory Inventory { get; }

    // Метод, необходимый планировщику для создания ветвей
    IBlackboard Clone();

    // Вспомогательный метод для регистрации новых свойств
    void Register(IWorldProperty p);
    string DebugDump();
}
