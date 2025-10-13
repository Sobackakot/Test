using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

// CookFoodAction: Преобразует RawFood в CookedFood. Требует FireStarter.
public class CookFoodAction : GOAPAction
{
    public CookFoodAction(IRandomizerService randomizer) : base(randomizer)
    {
        _Name = "CookFood"; _Cost = 3.0f; _BaseDuration = 6.0f; _BaseFailChance = 0.15f;
        _RequiredItems = new ItemType[] { ItemType.FireStarter, ItemType.Cookware };
    }
    public override bool CheckPreconditions(IBlackboard bb)
    {
        return (bb.TryGet<RawFoodProp>(out var r) && r.Value >= 1) && (GetRelevantTool(bb) != null);
    }
    public override void ApplyEffects(IBlackboard bb)
    {
        if (bb.TryGet<RawFoodProp>(out var r) && r.Value >= 1)
        {
            r.Value -= 1;
            if (!bb.TryGet<CookedFoodProp>(out var c)) c = new CookedFoodProp(0);
            c.Value += 1;
            bb.Register(c);
        }
    }
    public override IEnumerator Perform(IBlackboard bb)
    {
        Item tool = GetRelevantTool(bb);
        float quality = tool?.QualityPercent ?? 100f;
        yield return new WaitForSeconds(Randomizer.CalculateEffectiveDuration(_BaseDuration, quality));

        float failChance = Randomizer.CalculateEffectiveFailChance(_BaseFailChance, quality, 0f);
        if (Randomizer.GetRandomFloat() >= failChance) ApplyEffects(bb);
    }
}
