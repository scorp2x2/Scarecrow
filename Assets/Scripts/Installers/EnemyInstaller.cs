using System;
using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Enemy>().AsSingle();
        Container.BindInterfacesAndSelfTo<EnemyStateManager>().AsSingle();
        Container.Bind<EnemyStateBurning>().AsSingle();
        Container.Bind<EnemyStateWetness>().AsSingle();
        Container.Bind<EnemyStateIdle>().AsSingle();
    }
}