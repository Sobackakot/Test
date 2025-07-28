using EntityAI;
using EntityAI.Config;
using EntityAI.Factory;



namespace EntityAI.Creator
{
    public interface ICreator  
    {
       void Creating(IFactory factory); 
    }
}