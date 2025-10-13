using System;
using System.Collections.Generic;


public class EatGoal : GOAPGoal
{
    public override string Name => "EatUntilSatiated";
    private readonly float _threshold;
    public EatGoal(float priority = 3f, float threshold = 20f) : base(priority) { _threshold = threshold; }
    public override bool IsSatisfied(IBlackboard bb)
    {
        if (!bb.TryGet<HungerProperty>(out var h)) return false;
        return h.Value <= _threshold;
    }
}