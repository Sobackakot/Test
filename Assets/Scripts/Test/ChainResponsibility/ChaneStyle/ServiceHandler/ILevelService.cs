using Chain.Service.Client;
using EntityAI.Factory;

namespace Chain.Service
{
    public interface ILevelService
    {
        ILevelService SetNext(ILevelService handler);
        void Handle(IGameLevel difficultyLevel);
    }
}

