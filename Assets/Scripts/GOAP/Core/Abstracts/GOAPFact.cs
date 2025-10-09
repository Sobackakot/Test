using System;
using UnityEngine;

[Serializable]
public abstract class GOAPFact
{
    // Ключ - это имя класса.
    public string GetKey()
    {
        return GetType().Name;
    }

    // Методы для планировщика и работы с данными
    public abstract object GetValueAsObject();
    public abstract bool IsMatch(GOAPFact factToMatch);
    public abstract GOAPFact Clone();
    public abstract object GetValue();
}