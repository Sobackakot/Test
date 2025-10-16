using EntityAI.GOAP.Action;
using System.Collections;
using UnityEngine;

// Действие: Разжечь огонь
public class GOAPLightFireAction : GOAPAction
{
    public GOAPLightFireAction(IRandomizerService randomizer) : base(randomizer)
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