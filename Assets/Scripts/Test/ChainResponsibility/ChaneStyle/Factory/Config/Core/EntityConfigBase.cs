using System.Collections.Generic;

namespace Entity.Config
{
    public abstract class EntityConfigBase : IEntityConfig
    {
        private Dictionary<EntityType, IEntity> _entities = new() ;
        public Dictionary<EntityType, IEntity> entities => _entities;

        public void AddEntity(IEntity entity)
        {
            if (entities.ContainsKey(entity.entityType)) return;
            entities[entity.entityType] = entity;
        }

        public IEntity GetEntity(EntityType type)
        {
            return entities.TryGetValue(type, out var entity) ? entity : default;
        }
    }

}
