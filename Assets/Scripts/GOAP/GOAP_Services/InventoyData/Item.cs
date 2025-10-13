
// Item: Хранит состояние (Durability) и качество (QualityPercent).
using UnityEngine;

public class Item
{
    public ItemType Type { get; private set; }
    public float QualityPercent { get; private set; } // 0 to 100
    public float Durability { get; set; } = 100f;

    public bool IsBroken => Durability <= 0f;

    public Item(ItemType type, float quality)
    {
        Type = type;
        QualityPercent = Mathf.Clamp(quality, 1f, 100f);
        Durability = 100f; // Всегда начинается с 100%
    }

    public Item DeepCopy() => new Item(Type, QualityPercent) { Durability = Durability };
}
public enum ItemType { SelfMadeBow, SelfMadeArrow, Crossbow, Bolt, SelfMadeAxe, FoundAxe, FireStarter, Cookware, Wood }