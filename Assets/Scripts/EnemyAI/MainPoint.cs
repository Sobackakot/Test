using EntityAI.Factory;
using EntityAI.Repository;
using Entity;
using Entity.Config;
using EntityAI.Creator;
using UnityEngine;
 
public class MainPoint : MonoBehaviour
{
    private IEntityConfig config; 
    private IEntityRepository repository;
    private ICreator creator;

    private IFactory factory;


    private void Awake()
    {
        config = FindObjectOfType<EntityConfig>();
        repository = new EntityRepository();
        creator = new EntityCreator(repository, config);  
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            factory = new FireFactory();
            creator.Creating(factory);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            factory = new FreezFactory();
            creator.Creating(factory);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            factory = new EllectroFactory();
            creator.Creating(factory);
        }
        repository?.Tick();
    }
    private void LateUpdate()
    {
        repository?.LateTick();
    }
    private void FixedUpdate()
    {
        repository?.FixedTick();
    }
}
