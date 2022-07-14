using UnityEngine;
using Zenject;

public class GameSignalInstaller : Installer<GameSignalInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<InputStateSignalButtonE>();
        Container.DeclareSignal<InputStateSignalButtonQ>();
        Container.DeclareSignal<InputStateSignalButtonR>();

        Container.DeclareSignal<EnemyDiedSignal>();
    }
}