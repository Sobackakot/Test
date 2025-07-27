using Chain.Service.Client;
using EntityAI.Creator;
using EntityAI.Factory;

namespace Chain.Service
{
    public abstract class LevelServiceBase : ILevelService
    { 
        private ILevelService _nextHandler;
        public virtual void Handle(IGameLevel client)
        {
            _nextHandler?.Handle(client);
        }

        public ILevelService SetNext(ILevelService handler)
        {
            _nextHandler = handler;
            return handler;
        }
    }
}

