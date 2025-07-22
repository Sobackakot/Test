namespace Chain.Service.Client
{
    public abstract class GameLevelBase : IGameLevel
    {
        public GameLevelBase(LevelType levelType)
        {
            _levelType = levelType;
        }
        protected private LevelType _levelType = LevelType.Simple;
        public abstract LevelType levelType { get; }
        public abstract void SetGameLevel(LevelType levelType);
    }
}

