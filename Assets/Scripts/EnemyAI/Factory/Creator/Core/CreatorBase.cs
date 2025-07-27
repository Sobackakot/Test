using EntityAI;
using EntityAI.Config;
using EntityAI.Factory;


namespace EntityAI.Creator
{
    public abstract class CreatorBase : ICreator
    { 
        public void Creating(IFactory factory,IEntityResources config)
        {
           IEntity entity = factory.NewEntity(config);  
        }
         
    }
}


