using EntityAI.GOAP.Action;
using System.Collections;
using UnityEngine;

public class CraftWeaponAction : GOAPAction
{
    public CraftWeaponAction(IRandomizerService randomizer) : base(randomizer) { _Name = "CraftWeapon"; _Cost = 2f; _BaseDuration = 8f; }
    public override bool CheckPreconditions(IBlackboard bb) => true;
    public override void ApplyEffects(IBlackboard bb) { bb.Inventory.Add(new Item(ItemType.SelfMadeBow, 90f)); }
    public override IEnumerator Perform(IBlackboard bb) { yield return new WaitForSeconds(_BaseDuration); }
}
