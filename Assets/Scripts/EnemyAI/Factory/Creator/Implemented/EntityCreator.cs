
using Entity.Config;
using EntityAI.Repository;

namespace EntityAI.Creator
{
    public class EntityCreator : CreatorBase
    {
        public EntityCreator(IEntityRepository entityRep, IEntityConfig config) : base(entityRep, config)
        {
        }
    }
}
