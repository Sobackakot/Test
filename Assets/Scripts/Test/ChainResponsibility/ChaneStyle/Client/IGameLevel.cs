using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chain.Service.Client
{
    public interface IGameLevel
    {
        LevelType levelType { get;}
        void SetGameLevel(LevelType levelType);
    }
    public enum LevelType
    {
       Simple,
       Middle,
       Hardcore,
       None
    }
}

