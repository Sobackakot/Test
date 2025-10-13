using System.Collections;
using UnityEngine;

public class FindWeaponAction : GOAPAction
{
    public FindWeaponAction(IRandomizerService randomizer) : base(randomizer) { _Name = "FindWeapon"; _Cost = 1f; _BaseDuration = 10f; }
    public override bool CheckPreconditions(IBlackboard bb) => true;
    public override void ApplyEffects(IBlackboard bb) { bb.Inventory.Add(new Item(ItemType.Crossbow, 60f)); }
    public override IEnumerator Perform(IBlackboard bb) { yield return new WaitForSeconds(_BaseDuration); }
}
