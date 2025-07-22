using Entity;
using Factory;

namespace Creator
{
    public abstract class CreatorBase : ICreator
    {
        public void Creating(IFactory factory)
        {
            factory.CrateEnemy();
        }
    }
}


