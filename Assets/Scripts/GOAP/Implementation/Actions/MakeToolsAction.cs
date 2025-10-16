using EntityAI.GOAP.Action;
using System.Collections;
using UnityEngine;
// E. Simple Utility Action (Required for Compile)
public class MakeToolsAction : GOAPAction
{
    public MakeToolsAction(IRandomizerService randomizer) : base(randomizer) { _Name = "MakeTools"; _Cost = 1f; _BaseDuration = 5f; }
    public override bool CheckPreconditions(IBlackboard bb) => true; // Упрощенно
    public override void ApplyEffects(IBlackboard bb) { bb.Inventory.Add(new Item(ItemType.Cookware, 80f)); }
    public override IEnumerator Perform(IBlackboard bb) { yield return new WaitForSeconds(_BaseDuration); }
     
}
