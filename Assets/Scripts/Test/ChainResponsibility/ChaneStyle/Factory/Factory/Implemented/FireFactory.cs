using Entity;
using Entity.Config;


namespace Factory
{
    public class FireFactory : FactoryBase
    {
        public FireFactory(IEntityConfig config) : base(config, EntityType.Fire)
        {
        }
    }
}