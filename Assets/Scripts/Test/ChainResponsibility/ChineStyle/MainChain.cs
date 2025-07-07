using Chain.Service;
using Chain.Service.Client; 
using UnityEngine;

public class MainChain : MonoBehaviour
{
    public DifficultyLevelType levelType;
    private IServiceHandler service;
    private IDifficultyLevel difficultyLevel;
    void Start()
    {
        difficultyLevel = new DifficultyLevel(DifficultyLevelType.Middle);
        
        service = new FreezSpellService();

        service.SetNext(new FireSpellService()).SetNext(new EllectroSpellService()); 
         
    }
     
    void Update()
    {
        difficultyLevel.SetDifficultyLevel(levelType);
        service.Handle(difficultyLevel);
    }
}
