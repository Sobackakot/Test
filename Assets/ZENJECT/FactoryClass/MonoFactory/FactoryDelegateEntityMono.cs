using Zenject;

public class FactoryDelegateEntityMono : IFactoryDelegateEntityMono
{
    public FactoryDelegateEntityMono(EntityFactoryMono factory)
    {
        _factory = factory;
    }
    public EntityFactoryMono _factory;
    public EntityMono Create(string id)
    {
        var newEntity = _factory.Create(id);
        newEntity.Initialize();
        return newEntity;
    }
}
public interface IFactoryDelegateEntityMono 
{
    EntityMono Create(string id);
}
 public class EntityFactoryMono : PlaceholderFactory<string , EntityMono>
{
     
}