using System.Collections;
using UnityEngine;



// Конкретное действие: Персонаж ест.
public class GOAPEatAction : GOAPAction
{
    public GOAPEatAction(IRandomizerService randomizer) : base(randomizer)
    {
    }

    public override void ApplyEffects(IBlackboard bb)
    {
        throw new System.NotImplementedException();
    }

    public override bool CheckPreconditions(IBlackboard bb)
    {
        throw new System.NotImplementedException();
    }

    public override IEnumerator Perform(IBlackboard bb)
    {
        throw new System.NotImplementedException();
    }
}