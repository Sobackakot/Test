using EntityAI.React;
using System.Collections.Generic;
using UnityEngine;

namespace EntityAI.Repository
{
    public class EntityRepository : ObserverContextBase<EntityActionType>, IEntityRepository
    {
        public EntityRepository(IActionSubject<EntityActionType, IObserverContext<EntityActionType>> subject) : base(subject)
        {
            Register(EntityActionType.EntityReg, (string id, IEntity entity) => RegisterEntity(id, entity));
            Register(EntityActionType.EntityUnreg, (string id, IEntity entity) => UnregisterEntity(id, entity));
            SubscribeAll();
        }

        Dictionary<string, IEntity> _entitiesAI = new(); 
        public Dictionary<string, IEntity>  entitiesAI => _entitiesAI;

        private List<IEntity> _entities = new();
        public List<IEntity> entities => _entities;

        public void Enter()
        {
            Register(EntityActionType.EntityReg, (string id, IEntity entity) => RegisterEntity(id, entity));
            Register(EntityActionType.EntityUnreg, (string id, IEntity entity) => UnregisterEntity(id, entity));
            SubscribeAll();
        }

        public void Exit()
        {
            UnsubscribeAll();
        }
        public void RegisterEntity(string id, IEntity entity)
        {
            if (!entitiesAI.ContainsKey(id))
            { 
                _entitiesAI.Add(id, entity); 
                _entities.Add(entity);
            }
        }

        public void UnregisterEntity(string id, IEntity entity)
        {
            if (entitiesAI.ContainsKey(id))
            {
                _entitiesAI.Remove(id);
                _entities.Remove(entity);
            }
        }

    
    }
}
