using EntityAI.Config;
using EntityAI.Factory;
using EntityAI.React;


namespace EntityAI.Creator
{
    public abstract class CreatorBase : ICreator
    {

        public CreatorBase(ICreatorEntityAISubject subjectCreator)
        {
            this.subjectCreator = subjectCreator;
        }
        private ICreatorEntityAISubject subjectCreator; // Это ваш IActionSubject для CreatorActionType

        // CreatorBase теперь принимает IGameResources
        public void Creating(IFactory factory)
        {
            // Фабрика теперь должна получать ресурсы (GameResourcesBase)
            // Но IFactory.NewEntity не принимает resources, если вы передали их в конструктор FactoryBase.
            // Если FactoryBase принимает resources в конструкторе, то NewEntity не должно их принимать.
            // Фабрика NewEntity, вероятно, должна принимать только spawnPoint
            // А IGameResources передаваться в конструктор самой фабрики (FireFactory, FreezFactory).

            // Давайте упростим, что Factory.NewEntity не принимает ресурсы, т.к. они уже в фабрике.
            IEntity entity = factory.NewEntity(); // NewEntity теперь не принимает IGameResources напрямую

            subjectCreator.InvokeAction(CreatorActionType.Creator, entity);
        }
    }
}


