using EntityAI.Planer;
using EntityAI.Context;
using Entity;
using System.Collections.Generic;


namespace EntityAI.Repository
{
    public class PlanerRepository : IPlanerRepository<IEntity>
    {
        public readonly Dictionary<IEntity, IPlaner<IContext>> planers = new();

        public void RegistryPlaner(IEntity enemy, IPlaner<IContext> planer) 
        {
            if (!planers.ContainsKey(enemy))
            {
                planers.Add(enemy, planer);
            }
        }

        public void UnRegistryEnemy(IEntity enemy)
        {
            if(planers.ContainsKey(enemy))
            {
                planers.Remove(enemy);
            }
        }
 
    }
}