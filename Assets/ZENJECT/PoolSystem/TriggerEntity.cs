using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class TriggerEntity : MonoBehaviour, ITriggerEntity
{
    [Inject] PoolSystemEntity _pool;
    [Inject] IRepoEntitys _repo;
    IEntityPrefab newEntity;
    public void SpawnedBT()
    {
        newEntity = _pool.Spawn();
      
    }
    public void DespawnedBT()
    {
        if (newEntity != null)
        {
            newEntity.Despawned();
            newEntity = null;
            return;
        }
        List<string > allID = _repo.GetEntitysID();
        if (allID.Count > 0 && _repo.TryGetEntity(allID[0], out IEntityPrefab entity))
        {
            entity.Despawned();
        }
    } 
}
public interface ITriggerEntity
{
    void SpawnedBT();
    void DespawnedBT();
}