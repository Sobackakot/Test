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
        private ICreatorEntityAISubject subjectCreator; // ��� ��� IActionSubject ��� CreatorActionType

        // CreatorBase ������ ��������� IGameResources
        public void Creating(IFactory factory)
        {
            // ������� ������ ������ �������� ������� (GameResourcesBase)
            // �� IFactory.NewEntity �� ��������� resources, ���� �� �������� �� � ����������� FactoryBase.
            // ���� FactoryBase ��������� resources � ������������, �� NewEntity �� ������ �� ���������.
            // ������� NewEntity, ��������, ������ ��������� ������ spawnPoint
            // � IGameResources ������������ � ����������� ����� ������� (FireFactory, FreezFactory).

            // ������� ��������, ��� Factory.NewEntity �� ��������� �������, �.�. ��� ��� � �������.
            IEntity entity = factory.NewEntity(); // NewEntity ������ �� ��������� IGameResources ��������

            subjectCreator.InvokeAction(CreatorActionType.Creator, entity);
        }
    }
}


