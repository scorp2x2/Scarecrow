using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WaterBall : Weapon, IPoolable<Vector3, IMemoryPool>
{
    WaterBullet.Factory _factory;

    [Inject]
    public void Construct(WaterBall.Settings settings, WaterBullet.Factory factory)
    {
        base.settings = settings;
        _factory = factory;
    }

    public void OnDespawned()
    {
        pool = null;
    }

    public void OnSpawned(Vector3 p1, IMemoryPool p2)
    {
        pool = p2;
    }

    public override void Shoot()
    {
        _factory.Create(transform);
    }

    [Serializable]
    public new class Settings : Weapon.Settings
    {
    }

    public class Factory : PlaceholderFactory<Vector3, WaterBall>
    {

    }
}
