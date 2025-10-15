using EntityAI;
using EntityAI.Config;


namespace EntityAI.Factory
{
    public interface IFactory 
    { 
        IEntity NewEntity(PoolSystem pool);
    }
}

