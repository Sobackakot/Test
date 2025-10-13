using System.Collections;
using UnityEngine;

// EatAction: Уменьшает Hunger, восстанавливает Energy. 
// Предпочитает CookedFood > FoodReserve > RawFood.
public class EatAction : GOAPAction
{
    public EatAction(IRandomizerService randomizer) : base(randomizer)
    {
        _Name = "EatFood"; _Cost = 1.0f; _BaseDuration = 1.0f; _BaseFailChance = 0.05f;
    }
    public override bool CheckPreconditions(IBlackboard bb)
    {
        return (bb.TryGet<CookedFoodProp>(out var c) && c.Value >= 1) ||
               (bb.TryGet<RawFoodProp>(out var r) && r.Value >= 1) ||
               (bb.TryGet<FoodReserveProp>(out var fr) && fr.Value >= 1);
    }
    public override void ApplyEffects(IBlackboard bb)
    {
        if (bb.TryGet<HungerProperty>(out var h)) h.Value = 0f;
        if (bb.TryGet<EnergyProperty>(out var e)) e.Value = 100f;

        if (bb.TryGet<CookedFoodProp>(out var c) && c.Value >= 1) { c.Value -= 1; }
        else if (bb.TryGet<FoodReserveProp>(out var fr) && fr.Value >= 1) { fr.Value -= 1; }
        else if (bb.TryGet<RawFoodProp>(out var r) && r.Value >= 1) { r.Value -= 1; }
    }
    public override IEnumerator Perform(IBlackboard bb)
    {
        yield return new WaitForSeconds(_BaseDuration);
        // Применяем эффекты сразу (еда - быстрое действие)
        ApplyEffects(bb);
    }
}
