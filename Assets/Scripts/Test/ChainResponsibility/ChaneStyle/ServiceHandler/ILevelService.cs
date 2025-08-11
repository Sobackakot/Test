using Chain.Service.Client;

namespace Chain.Service
{
    public interface ILevelService
    {
        ILevelService SetNext(ILevelService handler);
        void Handle(IGameLevel difficultyLevel);
    }
}

