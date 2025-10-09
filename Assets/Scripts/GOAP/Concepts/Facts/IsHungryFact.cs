using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IsHungryFact : BooleanFact
{
    public IsHungryFact(bool isHungry) : base(isHungry) { }
    public override GOAPFact Clone()
    {
        return new IsHungryFact(DesiredValue);
    }

    public override object GetValue()
    {
        throw new System.NotImplementedException();
    }
}
