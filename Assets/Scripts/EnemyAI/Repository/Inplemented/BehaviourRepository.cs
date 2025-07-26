using EnemyAI.Behaviour;
using Entity;
using System.Collections.Generic;


namespace EnemyAI.Repository
{
    public class BehaviourRepository : IBehaviourRepository<IEntity>
    {
        public readonly Dictionary<IEntity, IBehaviourHandler> behaviours = new();

        public void RegistryBehaviour(IEntity enemy, IBehaviourHandler handler)
        {
            if (!behaviours.ContainsKey(enemy))
            {
                behaviours.Add(enemy, handler);
            }
        }

        public void UnRegistryEnemy(IEntity enemy)
        {
            if(behaviours.ContainsKey(enemy))
            {
                behaviours.Remove(enemy);
            }
        }
    }
}