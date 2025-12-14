using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyTestBase  : IEntityPrefab
{
    public IRepoEntitys _repoEntitys { get; private set; }
    public DataEnemy _player { get; private set; }

    public GameObject GO { get; private set; }

    public string _id;
    public EnemyTestBase(string id ,DataEnemy player, IRepoEntitys repoEntitys )
    {
        _id = id;
        _player = player; 
        _repoEntitys  = repoEntitys;
        _repoEntitys.ReginsterEntity(id, this);
    } 
    public void SetPoolSystem(PoolSystemEntity pool)
    { 
    }
    public void Initialize()
    {
        _repoEntitys.ReginsterEntity(_id, this);
    }
    public void Despawned()
    {
        _repoEntitys.RemoveEntity(_id);
    }

    public void ShowNameEntity()
    {
        _player.ShowDataTest(_id);
    }

  
}

public class DataEnemy
{
    public void ShowDataTest(string id)
    {
        Debug.Log("new Enemy " + GetType().Name + " " + id);
    }
}

 