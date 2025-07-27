using EntityAI;
using System.Collections.Generic;

namespace EntityAI.Repository 
{
    public interface IEntityRepository  
    {  
        Dictionary<string, IEntity> entities { get; }

        void RegisterEntity(string id, IEntity enemy);

        void UnregisterEntity(string id); 
    }
}


