using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WaterBullet : Bullet, IPoolable<Transform, IMemoryPool>
{
    public new Rigidbody rigidbody;

    public float CountWetness { get => ((Settings)settings).CountWetness; }

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

        rigidbody.AddForce(new Vector3(0, ((Settings)settings).PowerForce, 0));

        _timeStart = Time.time;
    }

    [Serializable]
    public new class Settings : Bullet.Settings
    {
        public float CountWetness;
        public float PowerForce;
    }

    public class Factory : PlaceholderFactory<Transform, WaterBullet>
    {

    }
}

