using System;

[Serializable]
public abstract class BooleanFact : GOAPFact
{
    // Значение, которое требуется для предусловия или будет результатом эффекта.
    public bool DesiredValue;

    public BooleanFact(bool desiredValue)
    {
        DesiredValue = desiredValue;
    }

    public override object GetValueAsObject() => DesiredValue;

    public override bool IsMatch(GOAPFact factToMatch)
    {
        if (factToMatch is BooleanFact otherBoolFact)
        {
            return DesiredValue == otherBoolFact.DesiredValue;
        }
        return false;
    }
    public override GOAPFact Clone()
    {
        // Клонирование должно быть реализовано в конечных наследниках
        throw new NotImplementedException("Clone must be implemented in concrete BooleanFact subclasses.");
    }
    public override object GetValue()
    {
        return DesiredValue;
    }
}