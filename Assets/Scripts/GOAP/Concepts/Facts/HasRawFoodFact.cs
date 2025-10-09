using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class HasRawFoodFact : BooleanFact
{
    public HasRawFoodFact(bool hasFood) : base(hasFood) { }
    public override GOAPFact Clone()
    {
        return new HasRawFoodFact(DesiredValue);
    }

    public override object GetValue()
    {
        throw new System.NotImplementedException();
    }
}
