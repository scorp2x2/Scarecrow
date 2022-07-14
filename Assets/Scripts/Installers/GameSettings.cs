using UnityEngine;
using Zenject;
using System;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Installers/GameSettings")]
public class GameSettings : ScriptableObjectInstaller<GameSettings>
{
    [Header("Настройки для игрока")]
    public PlayerSettings Player;
    [Header("Настройки для чучела")]
    public EnemySettings Enemy;
    [Header("Настройки для оружия")]
    public WeaponSettings Weapons;
    [Header("Настройки для патронов")]
    public BulletSettings Bullets;

    [Header("Привязка префабов")]
    public GameInstaller.Settings GlobalSettings;

    public override void InstallBindings()
    {
        Container.BindInstance(Player.PlayerMoveSettings).IfNotBound();

        Container.BindInstance(Enemy.Settings).IfNotBound();
        Container.BindInstance(Enemy.StateWetness).IfNotBound();
        Container.BindInstance(Enemy.StateBurning).IfNotBound();

        Container.BindInstance(Weapons.FireBallSettings).IfNotBound();
        Container.BindInstance(Weapons.WaterBallSettings).IfNotBound();
        Container.BindInstance(Weapons.GunSettings).IfNotBound();

        Container.BindInstance(Bullets.FireBulletSettings).IfNotBound();
        Container.BindInstance(Bullets.WaterBulletSettings).IfNotBound();
        Container.BindInstance(Bullets.GunBulletSettings).IfNotBound();

        Container.BindInstance(GlobalSettings).IfNotBound();
    }

    [Serializable]
    public class PlayerSettings
    {
        public PlayerMoveHandler.Settings PlayerMoveSettings;
    }

    [Serializable]
    public class EnemySettings
    {
        public Enemy.Settings Settings;
        public EnemyStateBurning.Settings StateBurning;
        public EnemyStateWetness.Settings StateWetness;
    }

    [Serializable]
    public class WeaponSettings
    {
        public FireBall.Settings FireBallSettings;
        public WaterBall.Settings WaterBallSettings;
        public Gun.Settings GunSettings;
    }

    [Serializable]
    public class BulletSettings
    {
        public FireBullet.Settings FireBulletSettings;
        public WaterBullet.Settings WaterBulletSettings;
        public GunBullet.Settings GunBulletSettings;
    }
}