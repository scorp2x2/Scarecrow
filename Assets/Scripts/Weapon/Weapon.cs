using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour
{
    protected IMemoryPool pool;
    protected Settings settings;

    public float DelayShoot { get => settings.DelayShoot; }

    public virtual void Shoot()
    {

    }

    [Serializable]
    public class Settings
    {
        public float DelayShoot;
        public GameObject prefubBullet;
    }
}
