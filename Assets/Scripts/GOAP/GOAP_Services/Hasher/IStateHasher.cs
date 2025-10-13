using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateHasher
{
    // Метод, который берет абстрактный IBlackboard и вычисляет его хеш.
    int GetHash(IBlackboard bb);
}