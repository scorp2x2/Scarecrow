using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Gun : Weapon, IPoolable<Vector3, IMemoryPool>
{
    GunBullet.Factory _factory;

    [Inject]
    public void Construct(Gun.Settings settings, GunBullet.Factory factory)
    {
        base.settings = settings;
        _factory = factory;
    }

    public override void Shoot()
    {
        _factory.Create(transform);
    }

    public void OnDespawned()
    {
        pool = null;
    }

    public void OnSpawned(Vector3 p1, IMemoryPool p2)
    {
        pool = p2;
    }

    [Serializable]
    public new class Settings : Weapon.Settings
    {

    }

    public class Factory : PlaceholderFactory<Vector3, Gun>
    {

    }
}
