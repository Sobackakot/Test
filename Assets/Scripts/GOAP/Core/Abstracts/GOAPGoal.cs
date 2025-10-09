using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

// GOAPGoal: Класс, описывающий желаемое конечное состояние мира.
public abstract class GOAPGoal 
{
    public GOAPGoal(AgentContext Context)
    {
        this.Context = Context;
    }
    [Tooltip("Приоритет: Чем выше, тем важнее цель.")]
    public float priority = 1.0f;

    [Header("Целевое Состояние")]
    [SerializeReference]
    protected List<GOAPFact> factListGoalState = new List<GOAPFact>();

    protected AgentContext Context;

    protected virtual void Initializable()
    { 
        SetupGoal();
    } 
    // Метод для получения имени (используется для Debug.Log)
    public string GetGoalName()
    {
        return GetType().Name;
    }

    // 1. SetupGoal (остается)
    public abstract void SetupGoal();

    // 2. IsGoalAchieved (остается)
    public abstract bool IsGoalAchieved(Dictionary<Type, GOAPFact> worldState);

    public Dictionary<Type, GOAPFact> GetGoalState()
    {
        return factListGoalState.ToDictionary(f => f.GetType(), f => f);
    }

    protected void AddGoalFact(GOAPFact fact) => factListGoalState.Add(fact);
}