using System;
using UnityEngine;
using Zenject;

public class EntityPrefab : MonoBehaviour, IEntityPrefab 
{
    [Inject]
    public void Construct()
    { 
        GO = gameObject;
        tr = transform; 
    }
    public string ID { get; private set; }
    public GameObject GO { get; private set; } 
    public Transform tr { get; private set; }

    [Inject] IRepoEntitys _repo;
    public PoolSystemEntity _poolInstance { get; private set; }  

    public void Initialize()
    {
        ID = Guid.NewGuid().ToString(); 
        _repo.ReginsterEntity(ID, this);
    }
 
    public void SetPoolSystem(PoolSystemEntity pool)
    {
        _poolInstance = pool; // Сохраняем экземпляр
    }

    public void Despawned()
    {
        if (_poolInstance != null)  
        {
            _repo.RemoveEntity(ID);
            _poolInstance.Despawn(this);
        } 
    }

    public void ShowNameEntity()
    {
        print("new entity " + GetHashCode());
    }

    public void Update()
    {
        tr.Translate(Vector3.right * 2 * Time.deltaTime);
    }

  
}
