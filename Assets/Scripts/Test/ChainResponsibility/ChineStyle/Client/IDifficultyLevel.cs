using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chain.Service.Client
{
    public interface IDifficultyLevel
    {
        DifficultyLevelType levelType { get;}
        void SetDifficultyLevel(DifficultyLevelType levelType);
    }
    public enum DifficultyLevelType
    {
       Simple,
       Middle,
       Hardcore,
       None
    }
}

