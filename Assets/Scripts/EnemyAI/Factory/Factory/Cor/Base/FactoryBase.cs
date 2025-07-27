using EntityAI;
using EntityAI.Config;
using UnityEngine;

namespace EntityAI.Factory
{
    public abstract class FactoryBase : IFactory
    {
        public FactoryBase(EntityType type)
        {
            this.type = type;
        }
         
        protected readonly EntityType type;
          
        public IEntity NewEntity(IEntityResources config)
        {
            IEntity entity = config.GetEntity(type);
            GameObject prefab = entity.components.prefab;
            GameObject newEnemy = GameObject.Instantiate(prefab, entity.config.spawnPoint, Quaternion.identity);
            return newEnemy.GetComponent<EnemyBase>();
        }
    }

}

