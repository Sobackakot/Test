using Chain.Service.Client;
using UnityEngine;

public class DifficultyLevel : DifficultyLevelBase
{
    public DifficultyLevel(DifficultyLevelType levelType) : base(levelType)
    {
    }
     
    public override DifficultyLevelType levelType => _levelType;
    public override void SetDifficultyLevel(DifficultyLevelType levelType)
    {
        if (this.levelType == levelType) return;
        _levelType = levelType;
        Debug.Log("start event change spell on " + levelType);
    }
}
