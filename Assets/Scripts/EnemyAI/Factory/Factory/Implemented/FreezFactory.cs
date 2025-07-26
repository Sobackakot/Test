using Entity;
using Entity.Config;


namespace Factory
{
    public class FreezFactory : FactoryBase
    {
        public FreezFactory(IEntityConfig config) : base(config, EntityType.Freez)
        {
        }
    }
}