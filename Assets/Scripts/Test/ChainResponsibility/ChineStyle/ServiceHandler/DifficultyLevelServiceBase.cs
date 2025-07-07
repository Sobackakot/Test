using Chain.Service.Client;

namespace Chain.Service
{
    public abstract class DifficultyLevelServiceBase : IServiceHandler
    {
        private IServiceHandler _nextHandler;
        public virtual void Handle(IDifficultyLevel client)
        {
            _nextHandler?.Handle(client);
        }

        public IServiceHandler SetNext(IServiceHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }
    }
}

