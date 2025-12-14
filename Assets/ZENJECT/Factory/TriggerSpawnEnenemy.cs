using System;
using UnityEngine;
using Zenject;

public class TriggerSpawnEnenemy  : ITickable
{
    public TriggerSpawnEnenemy(IEnemyFactory enemyFactory,IRepoEntitys repoEntitys)
    {
        _repoEntitys = repoEntitys;
        _enemyFactory = enemyFactory;
    }
    readonly IEnemyFactory _enemyFactory;
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
