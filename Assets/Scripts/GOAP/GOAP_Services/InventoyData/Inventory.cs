
// Inventory: Хранит список Item и предоставляет методы доступа (GetBest, Count).
using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory: IInventory
{ 
    List<Item> _items = new List<Item>();
    public List<Item> items => _items;

    public void Add(Item item) => items.Add(item);
    public void Remove(Item item) => items.Remove(item);
    public void RemoveBroken() => items.RemoveAll(i => i.IsBroken); 

    // Получить лучший инструмент (с максимальным качеством)
    public Item GetBest(ItemType type) => items.Where(i => i.Type == type && !i.IsBroken).OrderByDescending(i => i.QualityPercent).FirstOrDefault();
    public Item GetAny(ItemType type) => items.FirstOrDefault(i => i.Type == type && !i.IsBroken);

    public Inventory DeepCopy()
    {
        var newInv = new Inventory();
        newInv._items = this.items.Select(i => i.DeepCopy()).ToList();
        return newInv;
    }

    public int GetItemsHash() => items.Count.GetHashCode() + items.Sum(i => i.Type.GetHashCode() + i.Durability.GetHashCode());
}
