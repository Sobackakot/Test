using EntityAI.Behaviour;
using EntityAI.Context;
using EntityAI.Planer;
using EntityAI.React;
using State.Machine;

namespace EntityAI
{
    public interface IEntityCommon
    {
        void InitializeEntityAI(

            IRepositorySubject entityRepository,
            IContext context,  
            IBehaviourHandler behaviourHandler,
            IStateMachine stateMachine,
            IPlaner<IContext> planer);

        void Initializable();
        void Disposable();
        void Tick();
        void LateTick();
        void FixedTick();
    }
}