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
         
        public void CrateEnemy()
        {
            var entity = config.GetEntity(type);
           GameObject.Instantiate(entity.prefab, entity.point, Quaternion.identity);
        }
    }

}

