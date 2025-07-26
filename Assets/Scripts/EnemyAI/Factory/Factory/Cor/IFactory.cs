using EnemyAI;
using Entity;


namespace Factory
{
    public interface IFactory 
    {
        IEntity GetNewEntity();
    }
}

