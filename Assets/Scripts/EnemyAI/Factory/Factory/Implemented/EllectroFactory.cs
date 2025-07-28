using EntityAI;
using EntityAI.Config;


namespace EntityAI.Factory
{
    public class EllectroFactory : FactoryBase
    {
        public EllectroFactory(IGameResources gameResources) : base(EntityType.Ellectro, gameResources)
        {
        }
    }
}