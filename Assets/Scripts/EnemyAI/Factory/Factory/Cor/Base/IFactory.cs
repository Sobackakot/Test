using EntityAI;
using EntityAI.Config;


namespace EntityAI.Factory
{
    public interface IFactory 
    {
        IGameResources resources { get; }
        IEntity NewEntity();
    }
}

