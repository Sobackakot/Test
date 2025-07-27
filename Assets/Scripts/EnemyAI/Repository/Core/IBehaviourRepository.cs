using EntityAI.Behaviour;
using Entity;

namespace EntityAI.Repository
{
    public interface IBehaviourRepository<Entity> where Entity : class, IEntity
    {
        void RegistryBehaviour(Entity enemy,IBehaviourHandler handler);
        void UnRegistryEnemy(Entity enemy);
    }
}