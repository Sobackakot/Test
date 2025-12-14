using UnityEngine;
using Zenject;

public class GameInstallerEntity : MonoInstaller
{
    [SerializeField] EntityPrefab ePref;
    [SerializeField] Transform trContainer;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<RepoEntitys>()
         .FromNew().AsSingle();

        Container.BindInterfacesAndSelfTo<TriggerEntity>()
            .FromComponentInHierarchy().AsSingle();

        Container.BindMemoryPool<EntityPrefab, PoolSystemEntity>()
            .WithInitialSize(100)
            .FromComponentInNewPrefab(ePref)
            .UnderTransform(trContainer);
    }
}