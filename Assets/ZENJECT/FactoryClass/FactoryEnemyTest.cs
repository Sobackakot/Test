using Zenject;

public class FactoryEnemyTest : IEnemyFactory
{
    public FactoryEnemyTest(EnemyFactory factory)
    {
        _factory = factory;
    }
    public EnemyFactory _factory;
    public EnemyTest Create(string id)
    {
        var newEntity = _factory.Create(id);
        newEntity.Initialize();
        return newEntity;
    }
}
public interface IEnemyFactory 
{
    EnemyTest Create(string id);
}
public class EnemyFactory : PlaceholderFactory<string , EnemyTest>
{
     
}