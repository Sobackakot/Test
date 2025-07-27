using Entity;
using State.Machine;
using System.Collections.Generic;


namespace EntityAI.Repository
{
    public class FSMRepository : IFSMRepository<IEntity>
    {
        public readonly Dictionary<IEntity, IStateMachine> machines = new();

        public void RegistryStateMachine(IEntity enemy, IStateMachine fsm)
        {
            if (!machines.ContainsKey(enemy))
            {
                machines.Add(enemy, fsm);
            }
        }

        public void UnRegistryEnemy(IEntity enemy)
        {
            if(machines.ContainsKey(enemy))
            {
                machines.Remove(enemy);
            }
        }
    }
}