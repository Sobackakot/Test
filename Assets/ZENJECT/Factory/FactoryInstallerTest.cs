using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class FactoryInstallerTest : MonoInstaller
{ 
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<TriggerSpawnEnenemy>().FromNew().AsSingle();
        Container.BindInterfacesTo<RepoEntitys>().FromNew().AsSingle();
        Container.Bind<DataEnemy>().AsSingle();

        Container.BindFactoryCustomInterface<string ,EnemyTestBase, EnemyFactory, IEnemyFactory>();
    }
}