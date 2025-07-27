using EntityAI;
using System.Collections.Generic;
using UnityEngine;

namespace Entity.Config
{
    public abstract class EntityConfigBase : MonoBehaviour, IEntityConfig
    { 
        [field: SerializeField] private List<EnemyBase> entitieTypesPrefab = new();
        [field: SerializeField] private List<Transform> spawnPoints = new();


        private Dictionary<EntityType, IEntity> _entities = new() ; 
        public Dictionary<EntityType, IEntity> entities => _entities;
         
        private void Awake()
        { 
            for (int i = 0; i < entitieTypesPrefab.Count; i++)
            {
                entitieTypesPrefab[i].SetSpawnPoint(spawnPoints[i].position);
            }
            foreach (var entity in entitieTypesPrefab)
            {
                
                if (!entities.ContainsKey(entity.entityType))
                {
                    _entities.Add(entity.entityType, entity);
                    Debug.Log(entity.GetType().Name);
                } 
            }
    
        }

        public IEntity GetEntity(EntityType type)
        { 
            return entities.TryGetValue(type, out var entity) ? entity : default;
        }
    }

}
