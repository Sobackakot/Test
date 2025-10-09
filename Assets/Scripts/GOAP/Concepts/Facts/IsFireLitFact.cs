using System;

// ФАКТ: Горит ли костер?
[Serializable]
public class IsFireLitFact : BooleanFact
{
    public IsFireLitFact(bool isFireLit) : base(isFireLit) { }

    public override GOAPFact Clone()
    {
        return new IsFireLitFact(DesiredValue);
    }

    public override object GetValue()
    {
        throw new NotImplementedException();
    }
}