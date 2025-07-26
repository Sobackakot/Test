using EnemyAI.Planer;
using EnemyAI.Context;
using Entity;

namespace EnemyAI.Repository
{
    public interface IPlanerRepository<Entity> where Entity : class, IEntity
    {
        void RegistryPlaner(Entity enemy, IPlaner<IContext> planer);

        void UnRegistryEnemy(Entity enemy);
    }
}