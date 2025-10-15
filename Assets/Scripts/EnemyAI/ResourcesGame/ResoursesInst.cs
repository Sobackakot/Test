namespace EntityAI.ResoucesGame 
{
    public static class ResoursesInst
    {
        public static IGameResources res { get; private set; }
        public static void SetResources(IGameResources resources) => res = resources;
    }
}

