using EntityAI.Config;
using UnityEngine;

namespace EntityAI.Factory
{
    public abstract class FactoryBase : IFactory
    {
        protected readonly EntityType type;
        protected readonly IGameResources _gameResources; 
        public IGameResources resources => _gameResources;
         
        public FactoryBase(EntityType type, IGameResources gameResources)
        {
            this.type = type;
            _gameResources = gameResources;
        }
         
        public IEntity NewEntity() 
        { 
            EntityConfige entityConfig = _gameResources.GetEntityConfig(type);

            if (entityConfig == null || entityConfig.prefab == null)
            {
                Debug.LogError($"Factory: No config or prefab found for EntityType: {type}");
                return null;
            } 
            GameObject newEnemyGo = GameObject.Instantiate(entityConfig.prefab, entityConfig.spawnPoint, Quaternion.identity);
             
            EntityAIBase entityAIBase = newEnemyGo.GetComponent<EntityAIBase>();

            if (entityAIBase == null)
            {
                Debug.LogError($"Factory: Prefab for {type} does not have an EntityAIBase component!");
                GameObject.Destroy(newEnemyGo);  
                return null;
            }
             
            entityConfig.SetEntityInstanceId(System.Guid.NewGuid().ToString()); 
            return entityAIBase;
        }
    }

}

