using Chain.Service.Client;
using UnityEngine;

public class GameLevel : GameLevelBase
{
    public GameLevel(LevelType levelType) : base(levelType) { }
     
    public override LevelType levelType => _levelType;
    public override void SetGameLevel(LevelType levelType)
    {
        if (this.levelType == levelType) return;
        _levelType = levelType;
         
    }
}
