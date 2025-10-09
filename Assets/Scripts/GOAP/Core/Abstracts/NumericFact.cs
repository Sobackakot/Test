// Ïğèìåğ: NumericFact.cs
using System;

[Serializable]
public abstract class NumericFact : GOAPFact
{
    public int CurrentValue { get; protected set; }

    // ...

    // *** ĞÅÀËÈÇÀÖÈß GetValue() ***
    public override object GetValue()
    {
        return CurrentValue;
    }
}