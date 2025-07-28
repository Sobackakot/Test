using EntityAI.Config;

namespace EntityAI.Factory
{
    public class FreezFactory : FactoryBase
    {
        public FreezFactory(IGameResources gameResources) : base(EntityType.Freez, gameResources)
        {
        }
    }
}