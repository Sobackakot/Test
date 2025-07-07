using Chain.Service.Client;

namespace Chain.Service
{
    public abstract class ServiceHandlerBase : IServiceHandler
    {
        private IServiceHandler _nextHandler;
        public virtual void Handle(ISpell client)
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

