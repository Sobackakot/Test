using EntityAI.GOAP.Action;
using System.Collections;
using UnityEngine;

public class ChopWoodAction : GOAPAction
{
    public ChopWoodAction(IRandomizerService randomizer) : base(randomizer) { _Name = "ChopWood"; _Cost = 1f; _BaseDuration = 3f; _RequiredItems = new ItemType[] { ItemType.FoundAxe }; }
    public override bool CheckPreconditions(IBlackboard bb) => bb.Inventory.GetBest(ItemType.FoundAxe) != null;
    public override void ApplyEffects(IBlackboard bb) { if (!bb.TryGet<WoodProp>(out var w)) w = new WoodProp(0); w.Value += 5; bb.Register(w); }
    public override IEnumerator Perform(IBlackboard bb) { yield return new WaitForSeconds(_BaseDuration); }
}
