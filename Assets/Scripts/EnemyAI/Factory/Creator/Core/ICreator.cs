using Entity;
using Entity.Config;
using EntityAI.Factory;
using EntityAI.Repository;



namespace EntityAI.Creator
{
    public interface ICreator  
    {
        void Creating(IFactory factory);
    }
}