using System.Collections.Generic;

namespace EntityAI.Config
{
    public interface IGameResources
    {
        Dictionary<EntityType, EntityConfige> entities { get;}
        EntityConfige GetEntityConfig(EntityType type); 
    } 
}
