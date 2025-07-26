using Factory;



namespace Creator
{
    public interface ICreator  
    {
        void Creating(IFactory factory);
    }
}