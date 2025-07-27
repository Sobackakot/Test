using Entity;
using Entity.Config;


namespace EntityAI.Factory
{
    public interface IFactory 
    {
        IEntity NewEntity(IEntityConfig config);
    }
}

