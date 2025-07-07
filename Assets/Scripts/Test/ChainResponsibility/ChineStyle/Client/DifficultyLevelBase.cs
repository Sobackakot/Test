namespace Chain.Service.Client
{
    public abstract class DifficultyLevelBase : IDifficultyLevel
    {
        public DifficultyLevelBase(DifficultyLevelType levelType)
        {
            _levelType = levelType;
        }
        protected private DifficultyLevelType _levelType = DifficultyLevelType.Hardcore;
        public abstract DifficultyLevelType levelType { get; }
        public abstract void SetDifficultyLevel(DifficultyLevelType levelType);
    }
}

