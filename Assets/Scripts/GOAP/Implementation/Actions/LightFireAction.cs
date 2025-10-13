using System.Collections;
using UnityEngine;

public class LightFireAction : GOAPAction
{
    public LightFireAction(IRandomizerService randomizer) : base(randomizer) { _Name = "LightFire"; _Cost = 1f; _BaseDuration = 3f; }
    public override bool CheckPreconditions(IBlackboard bb) => true;
    public override void ApplyEffects(IBlackboard bb) { bb.Inventory.Add(new Item(ItemType.FireStarter, 100f)); }
    public override IEnumerator Perform(IBlackboard bb) { yield return new WaitForSeconds(_BaseDuration); }
}
