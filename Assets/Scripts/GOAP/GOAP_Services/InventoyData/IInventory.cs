using System.Collections.Generic;

public interface IInventory
{
    List<Item> items { get; }

    void Add(Item item);
    void Remove(Item item);
    void RemoveBroken(); 

    // Получить лучший инструмент (с максимальным качеством)
    Item GetBest(ItemType type);
    Item GetAny(ItemType type);

    Inventory DeepCopy();

    int GetItemsHash();
}
