using EnemyAI.Repository;
using Entity;
using Factory;

namespace Creator
{
    public abstract class CreatorBase : ICreator
    {
        public CreatorBase(IEntityRepository<IEntity> entityRep)
        {
            this.entityRep = entityRep; 
        }

        IEntityRepository<IEntity> entityRep; 

        public void Creating(IFactory factory)
        {
            var entity = factory.GetNewEntity();
            entityRep.RegistryEntity(entity.entityId, entity); 
        }
    }
}


