using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Inject] Settings _settings = null;
    [Inject] WaterBall.Settings _waterBallSettings;
    [Inject] Gun.Settings _gunSettings;

    public override void InstallBindings()
    {
        Container.Bind<InputState>().AsSingle();

        Container.BindFactory<Vector3, Weapon, Loot, Loot.Factory>()
                .FromPoolableMemoryPool<Vector3, Weapon, Loot, LootPool>(poolBinder => poolBinder
                .WithInitialSize(6)
                .FromComponentInNewPrefab(_settings.prefubLoot));

        Container.BindFactory<Vector3, Gun, Gun.Factory>()
                .FromPoolableMemoryPool<Vector3, Gun, GunPool>(poolBinder => poolBinder
                .WithInitialSize(2)
                .FromComponentInNewPrefab(_settings.prefubGun));

        Container.BindFactory<Vector3, WaterBall, WaterBall.Factory>()
                .FromPoolableMemoryPool<Vector3, WaterBall, WaterBallPool>(poolBinder => poolBinder
                .WithInitialSize(2)
                .FromComponentInNewPrefab(_settings.prefubWaterStone));

        Container.BindFactory<Vector3, FireBall, FireBall.Factory>()
                .FromPoolableMemoryPool<Vector3, FireBall, FireBallPool>(poolBinder => poolBinder
                .WithInitialSize(2)
                .FromComponentInNewPrefab(_settings.prefubFireStone));

        Container.BindFactory<Transform, GunBullet, GunBullet.Factory>()
                .FromPoolableMemoryPool<Transform, GunBullet, GunBulletPool>(poolBinder => poolBinder
                .FromComponentInNewPrefab(_gunSettings.prefubBullet));

        Container.BindFactory<Transform, WaterBullet, WaterBullet.Factory>()
                .FromPoolableMemoryPool<Transform, WaterBullet, WaterBulletPool>(poolBinder => poolBinder
                .FromComponentInNewPrefab(_waterBallSettings.prefubBullet));

        Container.Bind<Game>().AsSingle();
        GameSignalInstaller.Install(Container);
    }

    [Serializable]
    public class Settings
    {
        public GameObject prefubGun;
        public GameObject prefubWaterStone;
        public GameObject prefubFireStone;

        public GameObject prefubLoot;
    }

    class LootPool : MonoPoolableMemoryPool<Vector3, Weapon, IMemoryPool, Loot>
    {
    }

    class GunPool : MonoPoolableMemoryPool<Vector3, IMemoryPool, Gun>
    {
    }
    class WaterBallPool : MonoPoolableMemoryPool<Vector3, IMemoryPool, WaterBall>
    {
    }

    class FireBallPool : MonoPoolableMemoryPool<Vector3, IMemoryPool, FireBall>
    {
    }

    class GunBulletPool : MonoPoolableMemoryPool<Transform, IMemoryPool, GunBullet>
    {
    }

    class WaterBulletPool : MonoPoolableMemoryPool<Transform, IMemoryPool, WaterBullet>
    {
    }
}