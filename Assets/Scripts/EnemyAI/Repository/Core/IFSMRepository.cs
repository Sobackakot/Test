using Entity;
using State.Machine;

namespace EntityAI.Repository
{
    public interface IFSMRepository<Entity> where Entity : class, IEntity
    {
        void RegistryStateMachine(Entity enemy,IStateMachine fsm);
        void UnRegistryEnemy(Entity enemy);
    }
}