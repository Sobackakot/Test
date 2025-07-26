using Creator;
using EnemyAI.Repository;
using Entity;
using Entity.Config;
using Factory;
using UnityEngine;
 
public class MainPoint : MonoBehaviour
{
    private IEntityConfig config; 
    private IEntityRepository<IEntity> repository;
    private ICreator creator;

    private IFactory factory;


    private void Awake()
    {
        config = FindObjectOfType<EntityConfig>();
        repository = new EntityRepository();
        creator = new EntityCreator(repository);  
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            factory = new FireFactory(config);
            creator.Creating(factory);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            factory = new FreezFactory(config);
            creator.Creating(factory);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            factory = new EllectroFactory(config);
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
