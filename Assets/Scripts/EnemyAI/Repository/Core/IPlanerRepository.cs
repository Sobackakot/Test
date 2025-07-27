using EntityAI.Planer;
using EntityAI.Context;
using Entity;

namespace EntityAI.Repository
{
    public interface IPlanerRepository<Entity> where Entity : class, IEntity
    {
        void RegistryPlaner(Entity enemy, IPlaner<IContext> planer);

        void UnRegistryEnemy(Entity enemy);
    }
}