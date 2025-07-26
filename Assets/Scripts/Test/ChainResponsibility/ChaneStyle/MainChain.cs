using Chain.Service;
using Chain.Service.Client;
using UnityEngine;

public class MainChain : MonoBehaviour
{ 
    private ILevelService lvlService;
    private IGameLevel gameLevel;

    public LevelType levelType = LevelType.None;
     
    void Start()
    {  
        gameLevel = new GameLevel(LevelType.Middle);
        
        lvlService = new SimpleLevel();

        lvlService.SetNext(new HardcoreLevel())

            .SetNext(new MiddleLevel()); 
    }
     
    void Update()
    {
        gameLevel.SetGameLevel(levelType);
        lvlService.Handle(gameLevel);
    }
}
