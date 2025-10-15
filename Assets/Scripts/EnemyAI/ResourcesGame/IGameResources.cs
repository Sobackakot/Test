using EntityAI.Config;
using System.Collections.Generic;
using UnityEngine;

namespace EntityAI.ResoucesGame
{
    public interface IGameResources
    {
        List<EntityConfige> entityConfigs { get; }
        List<Transform> spawnPoints { get; }
        Dictionary<EntityType, EntityConfige> entities { get;}
        EntityConfige GetEntityConfig(EntityType type); 
    } 
}
