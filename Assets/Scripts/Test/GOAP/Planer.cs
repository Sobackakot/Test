using System.Collections.Generic;
using UnityEngine;

public class Planer<T> where T : IContext
{
    public readonly List<IAction<T>> actions = new();

    public void AddAction(IAction<T> action) => actions.Add(action);

    public void Run(T context)
    {
        foreach (var action in actions)
        {
            if (action.CanExecute(context))
            {
                action.Execute(context);
                break;
            }
        }
    }
}
