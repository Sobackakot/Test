using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Факты, которые понадобятся
[System.Serializable]
public class HasAxeFact : BooleanFact
{
    public HasAxeFact(bool hasAxe) : base(hasAxe) { }
    public override GOAPFact Clone() => new HasAxeFact(DesiredValue);

    public override object GetValue()
    {
        throw new System.NotImplementedException();
    }
}
