// PriorityQueue: Простая реализация Min-Heap для алгоритма A*.
using System.Collections.Generic;
using System;
using System.Linq;

public class PriorityQueue<T>
{
    private readonly List<Tuple<T, float>> _elements = new List<Tuple<T, float>>();
    public int Count => _elements.Count;

    public void Enqueue(T item, float priority)
    {
        _elements.Add(Tuple.Create(item, priority));
        _elements.Sort((x, y) => x.Item2.CompareTo(y.Item2));
    }

    public T Dequeue()
    {
        if (_elements.Count == 0) throw new InvalidOperationException("Queue is empty.");
        T bestItem = _elements[0].Item1;
        _elements.RemoveAt(0);
        return bestItem;
    }
}