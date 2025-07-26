using EnemyAI;
using System.Collections.Generic;

namespace Entity.Config
{
    public interface IEntityConfig
    {
        Dictionary<EntityType, EnemyBase> entities { get;}
         
        EnemyBase GetEntity(EntityType type);
    } 
}
