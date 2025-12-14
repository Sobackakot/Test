using Zenject;

public class PoolSystemEntity : MemoryPool<IEntityPrefab> 
{
    protected override void OnCreated(IEntityPrefab entity)
    {
        // ”станавливаем ссылку на пул сразу, чтобы избежать null при Despawned()
        entity.SetPoolSystem(this);

        base.OnCreated(entity);
        entity.GO.SetActive(false);
    }

    protected override void OnSpawned(IEntityPrefab entity)
    {
        entity.GO.SetActive(true);
        entity.Initialize();
    }

    protected override void OnDespawned(IEntityPrefab entity)
    {
        // ¬ Despawned() уже происходит удаление из репозитори€
        entity.GO.SetActive(false); 
    }
}
 