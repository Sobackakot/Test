using System.Collections.Generic;
using UnityEngine;

namespace EntityAI.Config
{
    public abstract class EntityResourcesBase : MonoBehaviour, IEntityResources
    { 
        [field: SerializeField] private List<EnemyBase> entitieTypesPrefab = new();
        [field: SerializeField] private List<Transform> spawnPoints = new();


        private Dictionary<EntityType, IEntity> _entities = new() ; 
        public Dictionary<EntityType, IEntity> entities => _entities;
         
        private void Awake()
        { 
            for (int i = 0; i < entitieTypesPrefab.Count; i++)
            {
                entitieTypesPrefab[i].config.SetSpawnPoint(spawnPoints[i].position);
            }
            foreach (var entity in entitieTypesPrefab)
            {
                var type = entity.config.entityType;
                 
                if (!entities.ContainsKey(type))
                {
                    _entities.Add(type, entity); 
                } 
            }
    
        }

        public IEntity GetEntity(EntityType type)
        { 
            return entities.TryGetValue(type, out var entity) ? entity : default;
        }
    }

}
