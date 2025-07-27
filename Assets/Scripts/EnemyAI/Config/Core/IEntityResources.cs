using System.Collections.Generic;

namespace EntityAI.Config
{
    public interface IEntityResources
    {
        Dictionary<EntityType, IEntity> entities { get;}

        IEntity GetEntity(EntityType type); 
    } 
}
