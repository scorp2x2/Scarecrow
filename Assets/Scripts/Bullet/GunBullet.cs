using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GunBullet : Bullet, IPoolable<Transform, IMemoryPool>
{
    public float Damage { get => settings.Damage; }

    [Inject]
    public void Construct(Settings settings)
    {
        base.settings = settings;
    }

    public void OnDespawned()
    {
        pool = null;
    }

    public void OnSpawned(Transform p1, IMemoryPool p2)
    {
        transform.position = p1.position;
        transform.rotation = p1.rotation;
        pool = p2;

        _timeStart = Time.time;
    }

    [Serializable]
    public new class Settings : Bullet.Settings
    {

    }

    public class Factory : PlaceholderFactory<Transform, GunBullet>
    {

    }
}
