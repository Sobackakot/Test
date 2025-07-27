using Entity;

namespace EntityAI.Repository
{
    public interface IRepository<Entity> where Entity : class, IEntity
    {
        void RegistryEnemy(Entity enemy); 
        void UnRegistryEnemy(Entity enemy);
    }
}