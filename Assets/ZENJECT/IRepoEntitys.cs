using System.Collections.Generic;

public interface IRepoEntitys
{
    bool TryGetEntity(string id, out IEntityPrefab entity);
    void ReginsterEntity(string id, IEntityPrefab entity);
    void RemoveEntity(string id);
    List<string> GetEntitysID();
    List<IEntityPrefab> GetEntitys();
}