using System;

// ФАКТ: Есть ли у персонажа дрова?
[Serializable]
public class HasWoodFact : BooleanFact
{
    public HasWoodFact(bool hasWood) : base(hasWood) { }

    public override GOAPFact Clone()
    {
        return new HasWoodFact(DesiredValue);
    }

    public override object GetValue()
    {
        throw new NotImplementedException();
    }
}