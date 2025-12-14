using Zenject;

public class FactoryEnemyTest : IFactory<string, EnemyTestBase>
{ 
    [Inject] public DiContainer _container; 
    public EnemyTestBase Create(string id)
    {
        return _container.Instantiate<EnemyTestBase>(new object[] {id});
    }
}
public interface IEnemyFactory : IFactory<string,EnemyTestBase> { }
public class EnemyFactory : PlaceholderFactory<string ,EnemyTestBase>, IEnemyFactory
{
     
}