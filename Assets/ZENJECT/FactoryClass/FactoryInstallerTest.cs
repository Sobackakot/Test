using UnityEngine;
using Zenject;

public class FactoryInstallerTest : MonoInstaller
{
    public GameObject EnemyPrefab;
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<TriggerSpawnEnenemy>().FromNew().AsSingle();
        Container.BindInterfacesTo<RepoEntitys>().FromNew().AsSingle();
       
        Container.Bind<DataEnemy>().AsSingle();

        Container.BindInterfacesTo<FactoryDelegateEntityMono>().FromNew().AsSingle(); // Bind Delegate Factory Entity MonoBehaviour
        Container.BindInterfacesTo<FactoryDelegateEntityTest>().FromNew().AsSingle();// Bind Delegate Factory Entity base

        //Container.BindFactoryCustomInterface<string ,EnemyTest, EnemyFactory, IEnemyFactory>(); 

        Container.BindFactory<string ,EntityMono, EntityFactoryMono>().FromComponentInNewPrefab(EnemyPrefab); // Bind Factory Entity MonoBehaviour

        Container.BindFactory<string, IEntityPrefab, EnemyFactory>().FromFactory<FactoryEntityTest>();// Bind Factory Entity base
    }
}