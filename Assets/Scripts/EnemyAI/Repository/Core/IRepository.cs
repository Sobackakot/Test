using Entity;

namespace EnemyAI.Repository
{
    public interface IRepository<Entity> where Entity : class, IEntity
    {
        void RegistryEnemy(Entity enemy); 
        void UnRegistryEnemy(Entity enemy);
    }
}