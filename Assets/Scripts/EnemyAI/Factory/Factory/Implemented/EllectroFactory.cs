using Entity;
using Entity.Config;


namespace Factory
{
    public class EllectroFactory : FactoryBase
    {
        public EllectroFactory(IEntityConfig config) : base(config,EntityType.Ellectro)
        {
        }
    }
}