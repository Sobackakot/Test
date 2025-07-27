using Entity.Config;
using EntityAI.Factory;
using EntityAI.Repository;

namespace EntityAI.Creator
{
    public abstract class CreatorBase : ICreator
    {
        public CreatorBase(

            IEntityRepository entityRep, 
            IEntityConfig config)
        {
            this.entityRep = entityRep;
            this.config = config;
        }

        IEntityRepository entityRep;
        IEntityConfig config;

        public void Creating(IFactory factory)
        {
            var entity = factory.NewEntity(config);
            entityRep.RegistryEntity(entity.entityId, entity); 
        } 
    }
}


