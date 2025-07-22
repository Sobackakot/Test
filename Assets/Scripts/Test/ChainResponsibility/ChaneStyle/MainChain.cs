using Chain.Service;
using Chain.Service.Client;
using Creator;
using Entity;
using Entity.Config;
using Factory;
using System.Collections.Generic;
using UnityEngine;

public class MainChain : MonoBehaviour
{
    private ICreator creator;
    private IEntityConfig config; 

    private ILevelService lvlService;
    private IGameLevel gameLevel;

    public LevelType levelType = LevelType.None;

    private void Awake()
    { 
        config = new EntityConfig();
        creator = new EntityCreator();

        int countEntityType = System.Enum.GetNames(typeof(EntityType)).Length;
        List<EntityBase> entities = new(countEntityType);
        entities.AddRange(FindObjectsOfType<EntityBase>());
        foreach (var entity in entities)
            config.AddEntity(entity);
    }
     
     
    void Start()
    {  
        gameLevel = new GameLevel(LevelType.Middle);
        
        lvlService = new SimpleLevel();

        lvlService.SetNext(new HardcoreLevel())

            .SetNext(new MiddleLevel());
        creator.Creating(new FireFactory(config));
    }
     
    void Update()
    {
        gameLevel.SetGameLevel(levelType);
        lvlService.Handle(gameLevel);
    }
}
