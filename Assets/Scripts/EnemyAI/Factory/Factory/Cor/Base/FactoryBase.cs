using EntityAI.Config;
using EntityAI.ResoucesGame;
using UnityEngine;

namespace EntityAI.Factory
{
    public abstract class FactoryBase : IFactory
    {
        protected readonly EntityType type; 
        public IGameResources resources { get; private set; }
        public FactoryBase(EntityType type)
        {
            this.type = type;
            resources = ResoursesInst.res;
        }
         
        public IEntity NewEntity(PoolSystem pool) 
        { 
            EntityConfige entityConfig = resources.GetEntityConfig(type);

            if (entityConfig == null || entityConfig.prefab == null)
            {
                Debug.LogError($"Factory: No config or prefab found for EntityType: {type}");
                return null;
            } 
            GameObject newEnemyGo = pool.ExtractFromPool(entityConfig);
             
            EntityAIBase entityAIBase = newEnemyGo.GetComponent<EntityAIBase>(); 

            if (entityAIBase == null)
            {
                Debug.LogError($"Factory: Prefab for {type} does not have an EntityAIBase component!");
                GameObject.Destroy(newEnemyGo);  
                return null;
            } 
            return entityAIBase;
        }
    }

}

