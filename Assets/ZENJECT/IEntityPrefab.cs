using UnityEngine;

public interface IEntityPrefab
{
    GameObject GO { get; }
    void SetPoolSystem(PoolSystemEntity pool);
     
    void Despawned();
    void ShowNameEntity();
    void Initialize();
}