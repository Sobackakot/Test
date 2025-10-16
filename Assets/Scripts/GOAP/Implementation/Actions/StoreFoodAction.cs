using EntityAI.GOAP.Action;
using System.Collections;
using UnityEngine;

// StoreFoodAction: Переносит еду из инвентаря в запас (FoodReserveProp).
public class StoreFoodAction : GOAPAction
{
    public StoreFoodAction(IRandomizerService randomizer) : base(randomizer)
    {
        _Name = "StoreFood"; _Cost = 1.0f; _BaseDuration = 2.0f; _BaseFailChance = 0.05f;
    }
    public override bool CheckPreconditions(IBlackboard bb)
    {
        if (bb.TryGet<CookedFoodProp>(out var c) && c.Value >= 1) return true;
        if (bb.TryGet<RawFoodProp>(out var r) && r.Value >= 1) return true;
        return false;
    }
    public override void ApplyEffects(IBlackboard bb)
    {
        if (bb.TryGet<CookedFoodProp>(out var c) && c.Value >= 1) { c.Value -= 1; }
        else if (bb.TryGet<RawFoodProp>(out var r) && r.Value >= 1) { r.Value -= 1; }

        if (!bb.TryGet<FoodReserveProp>(out var fr)) fr = new FoodReserveProp(0);
        fr.Value += 1;
        bb.Register(fr);
    }
    public override IEnumerator Perform(IBlackboard bb)
    {
        yield return new WaitForSeconds(Randomizer.CalculateEffectiveDuration(_BaseDuration, 100f));
        if (Randomizer.GetRandomFloat() >= _BaseFailChance) ApplyEffects(bb);
    }
}