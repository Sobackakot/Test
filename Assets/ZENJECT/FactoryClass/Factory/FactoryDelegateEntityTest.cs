public class FactoryDelegateEntityTest : IFactoryDelegateEntityTest
{
    public FactoryDelegateEntityTest(EnemyFactory factory)
    {
        _factory = factory;
    }
    public EnemyFactory _factory;

    public IEntityPrefab Create(string id)
    {
       var newEntity = _factory.Create(id);
        newEntity.Initialize();
        return newEntity;
    }
}
public interface IFactoryDelegateEntityTest
{
    IEntityPrefab Create(string id);
}