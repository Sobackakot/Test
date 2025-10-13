using System.Collections;
using UnityEngine;

// HuntAction: Добывает RawFood, требует оружие (лук/арбалет) и боеприпасы (стрелы/болты).
public class HuntAction : GOAPAction
{
    public HuntAction(IRandomizerService randomizer) : base(randomizer)
    {
        _Name = "HuntFood"; _Cost = 5.0f; _BaseDuration = 10.0f; _BaseFailChance = 0.3f;
        _RequiredItems = new ItemType[] { ItemType.SelfMadeBow, ItemType.Crossbow };
    }
    public override bool CheckPreconditions(IBlackboard bb)
    {
        bool hasWeapon = GetRelevantTool(bb) != null;
        bool hasAmmo = bb.Inventory.GetAny(ItemType.Bolt) != null || bb.Inventory.GetAny(ItemType.SelfMadeArrow) != null;
        return hasWeapon && hasAmmo;
    }
    public override void ApplyEffects(IBlackboard bb)
    {
        if (!bb.TryGet<RawFoodProp>(out var raw)) raw = new RawFoodProp(0);
        raw.Value += 2;
        bb.Register(raw);
        var ammo = bb.Inventory.GetAny(ItemType.SelfMadeArrow) ?? bb.Inventory.GetAny(ItemType.Bolt);
        if (ammo != null) bb.Inventory.Remove(ammo);
    }
    public override IEnumerator Perform(IBlackboard bb)
    {
        Item weapon = GetRelevantTool(bb);
        float quality = weapon?.QualityPercent ?? 100f;
        yield return new WaitForSeconds(Randomizer.CalculateEffectiveDuration(_BaseDuration, quality));

        float failChance = Randomizer.CalculateEffectiveFailChance(_BaseFailChance, quality, 0f);
        if (Randomizer.GetRandomFloat() >= failChance) ApplyEffects(bb); else Debug.LogWarning("[Hunt] Action failed.");
    }
}