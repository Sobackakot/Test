using EntityAI.GOAP.Action;
using System.Collections;
using UnityEngine;

public class GatherBerriesAction : GOAPAction
{
    public GatherBerriesAction(IRandomizerService randomizer) : base(randomizer) { _Name = "GatherBerries"; _Cost = 0.5f; _BaseDuration = 4f; }
    public override bool CheckPreconditions(IBlackboard bb) => true;
    public override void ApplyEffects(IBlackboard bb) { if (!bb.TryGet<RawFoodProp>(out var r)) r = new RawFoodProp(0); r.Value += 1; bb.Register(r); }
    public override IEnumerator Perform(IBlackboard bb) { yield return new WaitForSeconds(_BaseDuration); }
}