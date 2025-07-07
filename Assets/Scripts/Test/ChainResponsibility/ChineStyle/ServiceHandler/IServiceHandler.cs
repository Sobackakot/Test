using Chain.Service.Client;

namespace Chain.Service
{
    public interface IServiceHandler
    {
        IServiceHandler SetNext(IServiceHandler handler);
        void Handle(IDifficultyLevel difficultyLevel);
    }
}

