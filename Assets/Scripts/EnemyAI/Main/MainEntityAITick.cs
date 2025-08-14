using BehaviourFree;
using EntityAI.Config;
using EntityAI.Creator;
using EntityAI.Factory;
using EntityAI.Repository;
using UnityEngine;

public class MainEntityAITick : MonoBehaviour
{
    public IEntityRepository entityAIRepository { get; private set; }  
    public ICreatorEntityAISubject creatorEntityAISubject { get; private set; }
    public ICreator creator { get; private set; }
 
    public MainInitialize mainInit { get; private set; }
    public IGameResources resources { get; private set; }
    private void Awake()
    { 
        creatorEntityAISubject = new CreatorEntityAISubject();
        mainInit = new MainInitialize(creatorEntityAISubject);

        entityAIRepository = new EntityRepository(mainInit.repositorySubject);
        creator = new EntityCreator(creatorEntityAISubject);
        resources = FindObjectOfType<GameResources>();
      
    }
    private void OnEnable()
    {
        entityAIRepository?.Enter(); 
    }
    private void OnDisable()
    {
        entityAIRepository?.Exit(); 
    }
 
    private void Update()
    {
        foreach(var entity in entityAIRepository.entities)
        {
            entity?.Tick();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            creator.Creating(new FireFactory(resources));
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            creator.Creating(new FreezFactory(resources));
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            creator.Creating(new EllectroFactory(resources));
        }
    }
    private void LateUpdate()
    {
        foreach (var entity in entityAIRepository.entities)
        {
            entity?.LateTick();
        }
    }
    private void FixedUpdate()
    {
        foreach (var entity in entityAIRepository.entities)
        {
            entity?.FixedTick();
        }

    }
}
