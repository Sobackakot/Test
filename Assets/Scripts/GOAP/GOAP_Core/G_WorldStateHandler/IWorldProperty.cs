using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityAI.GOAP.WorldState
{
    public interface IWorldProperty
    {
        IWorldProperty Clone();
        object GetValue();
        void SetValue(object v);
    }
}