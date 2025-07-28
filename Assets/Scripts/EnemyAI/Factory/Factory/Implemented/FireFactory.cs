using EntityAI;
using EntityAI.Config;


namespace EntityAI.Factory
{
    public class FireFactory : FactoryBase
    {
        public FireFactory( IGameResources gameResources) : base(EntityType.Fire, gameResources)
        {
        }
    }
}