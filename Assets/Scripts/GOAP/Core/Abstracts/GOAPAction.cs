using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class GOAPAction  
{
    public GOAPAction(AgentContext Context)
    {
        this.Context = Context;
    }
    [Tooltip("Оценочная стоимость выполнения (трата энергии/времени)")]
    public float cost = 1.0f;

    [Header("Условия (GOAP Facts)")]
    // Храним факты в списке только для удобной настройки в Инспекторе
    [SerializeReference]
    protected List<GOAPFact> factListPreconditions = new List<GOAPFact>();

    [SerializeReference]
    protected List<GOAPFact> factListEffects = new List<GOAPFact>();

    // --- Ссылки ---
    protected AgentContext Context;
    protected bool isRunning = false;

    protected virtual void Initializable()
    { 
        SetupAction();
    }

    // Метод для получения имени (используется для Debug.Log)
    public string GetActionName()
    {
        return GetType().Name;
    }

    // 1. SetupAction (остается)
    public abstract void SetupAction();

    // --- Методы для GOAP-Планировщика (остаются) ---
    protected void AddPrecondition(GOAPFact fact) => factListPreconditions.Add(fact);
    protected void AddEffect(GOAPFact fact) => factListEffects.Add(fact);
    public Dictionary<Type, GOAPFact> GetPreconditions()
    {
        return factListPreconditions.ToDictionary(f => f.GetType(), f => f);
    }

    // Преобразует список в словарь, используя Type в качестве ключа.
    public Dictionary<Type, GOAPFact> GetEffects()
    {
        return factListEffects.ToDictionary(f => f.GetType(), f => f);
    }

    // --- Классические Методы Исполнения (остаются) ---
    public abstract bool CheckProceduralPrecondition();
    public abstract bool Perform();
    public abstract bool IsActionFinished();
    public abstract void Reset();
}