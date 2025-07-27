using EntityAI;
using EntityAI.Context;
using EntityAI.Planer;
using EntityAI.React;
using System.Collections.Generic;


namespace EntityAI.Repository
{
    public class PlanerRepository : ObserverContextBase<PlanerActionType>, IPlanerRepository 
    {
        public PlanerRepository(IActionSubject<PlanerActionType, IObserverContext<PlanerActionType>> subject) : base(subject)
        {
            Register(PlanerActionType.PlanerReg, (IEntity enemy, IPlaner<IContext> planer) => RegisterPlaner(enemy, planer));
            Register(PlanerActionType.PlanerUnreg, (IEntity enemy) => UnregistrerPlaner(enemy));
            SubscribeAll();
        }
        Dictionary<IEntity, IPlaner<IContext>> _planersAction = new();
         
        public Dictionary<IEntity, IPlaner<IContext>> planersAction => _planersAction;

        public void RegisterPlaner(IEntity enemy, IPlaner<IContext> planer) 
        {
            if (!planersAction.ContainsKey(enemy))
            {
                _planersAction.Add(enemy, planer);
            }
        }

        public void UnregistrerPlaner(IEntity enemy)
        {
            if(planersAction.ContainsKey(enemy))
            {
                _planersAction.Remove(enemy);
            }
        }
 
    }
}