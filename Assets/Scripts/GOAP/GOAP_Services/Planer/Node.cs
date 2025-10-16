using EntityAI.GOAP.Action;
using System;
using System.Collections.Generic;

// Node: Узел в графе поиска A*, представляет собой состояние мира и путь к нему.
public class Node
{
    public readonly Node Parent;
    public readonly float Cost;
    public readonly IBlackboard State;
    public readonly IGOAPAction Action;

    public Node(Node parent, float cost, IBlackboard state, IGOAPAction action)
    {
        Parent = parent;
        Cost = cost;
        State = state;
        Action = action;
    }

    // Возвращает список действий от корня до текущего узла.
    public List<IGOAPAction> GetActionPath()
    {
        var path = new List<IGOAPAction>();
        var current = this;
        while (current != null && current.Action != null)
        {
            path.Add(current.Action);
            current = current.Parent;
        }
        path.Reverse();
        return path;
    }
}
