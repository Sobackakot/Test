using EntityAI;
using System.Collections.Generic;

namespace Entity.Config
{
    public interface IEntityConfig
    {
        Dictionary<EntityType, IEntity> entities { get;}

        IEntity GetEntity(EntityType type);
    } 
}
