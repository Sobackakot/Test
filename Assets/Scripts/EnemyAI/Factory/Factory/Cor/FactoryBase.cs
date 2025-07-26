using EnemyAI;
using Entity;
using Entity.Config;
using UnityEngine;

namespace Factory 
{
    public abstract class FactoryBase : IFactory
    {
        public FactoryBase(IEntityConfig config, EntityType type)
        {
            this.config = config;
            this.type = type;
        }
         
        private readonly IEntityConfig config;
        protected readonly EntityType type;
         
        public IEntity GetNewEntity()
        {
            EnemyBase entity = config.GetEntity(type);
            GameObject prefab = entity.GetEntityPrefab();
            GameObject newEnemy = GameObject.Instantiate(prefab, entity.spawnPoint, Quaternion.identity);
            return newEnemy.GetComponent<EnemyBase>(); 
        }
    }

}

