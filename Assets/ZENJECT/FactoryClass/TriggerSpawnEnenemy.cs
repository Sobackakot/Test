using System;
using UnityEngine;
using Zenject;

public class TriggerSpawnEnenemy  : ITickable
{
    public TriggerSpawnEnenemy(
        IFactoryDelegateEntityMono enemyFactoryMono,
        IFactoryDelegateEntityTest enemyFactory,
        IRepoEntitys repoEntitys)
    { 
        _enemyFactoryMono = enemyFactoryMono;
        _enemyFactory = enemyFactory;
        _repoEntitys = repoEntitys; 
    }
    readonly IFactoryDelegateEntityMono _enemyFactoryMono;
    readonly IFactoryDelegateEntityTest _enemyFactory;
    public IRepoEntitys _repoEntitys { get; private set; }
     
    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            string id = Guid.NewGuid().ToString();
            _enemyFactory.Create(id); 
        }
        foreach(var entity in _repoEntitys.GetEntitys())
        {
            entity.ShowNameEntity();
        }
    }
}
