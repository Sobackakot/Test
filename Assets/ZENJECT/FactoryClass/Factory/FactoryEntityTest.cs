using Zenject;

public class FactoryEntityTest : IFactoryEntity
{
    public DiContainer _container;
    public FactoryEntityTest(DiContainer container)
    {
        _container = container;
    }
    public IEntityPrefab Create(string id)
    {
        return _container.Instantiate<EnemyTest>(new object[] { id });
    }
}
public class EnemyFactory : PlaceholderFactory<string , IEntityPrefab>, IFactoryEntity
{

}
public interface IFactoryEntity : IFactory<string, IEntityPrefab>
{

}
