using Entity;
using System.Collections.Generic;

namespace Entity.Config
{
    public interface IEntityConfig
    {
        Dictionary<EntityType, IEntity> entities { get; }

        void AddEntity(IEntity entity);
        IEntity GetEntity(EntityType type);
    } 
}
