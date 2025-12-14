using UnityEngine;

public class EnemyTest : IEntityPrefab
{
    public IRepoEntitys _repoEntitys { get; private set; }
    public DataEnemy _player { get; private set; }

    public GameObject GO { get; private set; }

    public string _id { get; private set; }
     
    public EnemyTest(string id ,DataEnemy player, IRepoEntitys repoEntitys )
    {
        _id = id;
        _player = player; 
        _repoEntitys  = repoEntitys; 
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
    public void SetPoolSystem(PoolSystemEntity pool)
    {
    }
}

 