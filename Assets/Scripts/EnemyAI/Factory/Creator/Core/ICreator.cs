using EntityAI.Config;
using EntityAI.Factory;



namespace EntityAI.Creator
{
    public interface ICreator  
    {
        PoolSystem pool { get;}
        void Creating(IFactory factory);
        void CreatingPool(int count, EntityConfige config);
    }
}