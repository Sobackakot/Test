using EnemyAI.Behaviour;
using Entity;

namespace EnemyAI.Repository
{
    public interface IBehaviourRepository<Entity> where Entity : class, IEntity
    {
        void RegistryBehaviour(Entity enemy,IBehaviourHandler handler);
        void UnRegistryEnemy(Entity enemy);
    }
}