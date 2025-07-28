using System.Collections.Generic;

namespace EntityAI.Repository 
{
    public interface IEntityRepository  : IRepository
    {  
        Dictionary<string, IEntity> entitiesAI { get; }
        List<IEntity> entities { get; }

        void RegisterEntity(string id, IEntity entity);

        void UnregisterEntity(string id, IEntity entity);
    
    }
}


