using EntityAI;
using EntityAI.Behaviour;
using EntityAI.React;
using System.Collections.Generic;


namespace EntityAI.Repository
{
    public class BehaviourRepository : ObserverContextBase<BehaviourHandlerActionType>,IBehaviourRepository
    {
        public BehaviourRepository(IActionSubject<BehaviourHandlerActionType, IObserverContext<BehaviourHandlerActionType>> subject) : base(subject)
        {
            Register(BehaviourHandlerActionType.BehaviourHandlerReg, (IEntity enemy, IBehaviourHandler handler) => RegisterBehaviour(enemy, handler));
            Register(BehaviourHandlerActionType.BehaviourHandlerUnreg, (IEntity enemy) => UnregisterBehaviour(enemy));
            SubscribeAll();
        }

        Dictionary<IEntity, IBehaviourHandler> _behaviourHandlers = new(); 
        public Dictionary<IEntity, IBehaviourHandler> behaviourHandlers => _behaviourHandlers;


        public void RegisterBehaviour(IEntity enemy, IBehaviourHandler handler)
        {
            if (!behaviourHandlers.ContainsKey(enemy))
                _behaviourHandlers.Add(enemy, handler);

        }

        public void UnregisterBehaviour(IEntity enemy)
        {
            if(behaviourHandlers.ContainsKey(enemy))
                _behaviourHandlers.Remove(enemy);

        }
    }
}