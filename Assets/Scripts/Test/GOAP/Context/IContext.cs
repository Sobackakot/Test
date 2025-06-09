namespace Test.Context
{
    public interface IContext
    {
        void Update();
        IContext Copy();
    }
}

