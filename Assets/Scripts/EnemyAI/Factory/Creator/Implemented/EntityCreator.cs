
using EnemyAI.Repository;
using Entity;

namespace Creator
{
    public class EntityCreator : CreatorBase
    {
        public EntityCreator(IEntityRepository<IEntity> entityRep) : base(entityRep)
        {
        }
    }
}
