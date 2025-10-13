using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGoapGoal  
{
    string Name { get; }
    float Priority { get; }
    bool IsSatisfied(IBlackboard bb);
}
