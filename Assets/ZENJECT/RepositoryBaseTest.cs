using System.Collections.Generic;

public abstract class RepositoryBaseTest : IRepoEntitys
{
    protected readonly Dictionary<string, IEntityPrefab> entitys = new Dictionary<string, IEntityPrefab>();
    protected readonly List<string> EntityID  = new List<string>();

    void IRepoEntitys.ReginsterEntity(string id, IEntityPrefab entity)
    {
        if (!entitys.ContainsKey(id))
        {
            entitys.Add(id, entity);
            EntityID.Add(id);
        }
    }

    bool IRepoEntitys.TryGetEntity(string id, out IEntityPrefab entity)
    {
        return entitys.TryGetValue(id, out entity);
    }

    void IRepoEntitys.RemoveEntity(string id)
    {
        if(entitys.ContainsKey(id))
        {
            entitys.Remove(id);
            EntityID.Remove(id);
        } 
    }

    List<string> IRepoEntitys.GetEntitysID()
    {
       return EntityID;
    }

    public List<IEntityPrefab> GetEntitys()
    {
        List<IEntityPrefab> entities = new List<IEntityPrefab>();
        foreach(var entity in entitys.Values)
        {
            entities.Add(entity);
        }
        return entities;
    }
}
