using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class FactoryInstallerTest : MonoInstaller
{

    public GameObject EnemyPrefab;
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<TriggerSpawnEnenemy>().FromNew().AsSingle();
        Container.BindInterfacesTo<RepoEntitys>().FromNew().AsSingle();
       
        Container.Bind<DataEnemy>().AsSingle();

        //Container.BindFactoryCustomInterface<string ,EnemyTest, EnemyFactory, IEnemyFactory>(); 
        //Container.BindFactory<string,IEntityPrefab, EnemyFactory>().FromFactory<FactoryEnemyTest>(); 

        Container.BindInterfacesTo<FactoryEnemyTest>().FromNew().AsSingle();
        Container.BindFactory<string ,EnemyTest, EnemyFactory>().FromComponentInNewPrefab(EnemyPrefab);
    }
}