using System;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public Settings settings;

    public override void InstallBindings()
    {
        Container.Bind<Player>().AsSingle().WithArguments(settings.CharacterController, settings.Camera);
        Container.BindInterfacesTo<PlayerMoveHandler>().AsSingle();
        Container.BindInterfacesTo<PlayerShootHandler>().AsSingle().WithArguments(settings.PlayerWeapons);
    }

    [Serializable]
    public class Settings
    {
        public CharacterController CharacterController;
        public PlayerWeapons PlayerWeapons;
        public Camera Camera;
    }
}