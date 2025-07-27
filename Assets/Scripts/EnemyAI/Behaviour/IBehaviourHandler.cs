namespace EntityAI.Behaviour
{
    public interface IBehaviourHandler 
    { 
        void RegisterBehaviour<T>(T behaviour) 
            where T : class, IBehaviourBase;
        T GetBehaviour<T>() 
            where T : class, IBehaviourBase;
    }
}

