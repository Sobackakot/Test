using Chain.Service.Client;

namespace Chain.Service
{
    public abstract class HandlerBotBase : IHandler
    {
        private IHandler _nextHandler;
        public virtual void Handle(IClient client)
        {
            _nextHandler?.Handle(client);
        }

        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }
    }
}

