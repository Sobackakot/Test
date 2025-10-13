using System;
using System.Collections.Generic;
using System.Linq;

// GOAPGoal: Класс, описывающий желаемое конечное состояние мира.
public abstract class GOAPGoal : IGoapGoal
{
    public abstract string Name { get; }
    public float Priority { get; protected set; }

    public GOAPGoal(float priority)
    {
        Priority = priority;
    }

    public abstract bool IsSatisfied(IBlackboard bb);
}