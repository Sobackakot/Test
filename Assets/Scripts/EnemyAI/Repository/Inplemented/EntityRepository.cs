using EntityAI;
using EntityAI.React;
using System.Collections.Generic;

namespace EntityAI.Repository
{
    public class EntityRepository : ObserverContextBase<EntityActionType>, IEntityRepository
    {
        public EntityRepository(IActionSubject<EntityActionType, IObserverContext<EntityActionType>> subject) : base(subject)
        {
            Register(EntityActionType.EntityReg, (string id, IEntity entity) => RegisterEntity(id, entity));
            Register(EntityActionType.EntityUnreg, (string id) => UnregisterEntity(id));
            SubscribeAll();
        }

        Dictionary<string, IEntity> _entities = new();
        public Dictionary<string, IEntity>  entities => _entities; 

         
        public void RegisterEntity(string id, IEntity enemy)
        {
            if (!entities.ContainsKey(id))
                _entities.Add(id, enemy); 
        }

        public void UnregisterEntity(string id)
        {
            if (entities.ContainsKey(id))
                _entities.Remove(id);
        } 
    }
}
