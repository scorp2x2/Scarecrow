using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Loot : MonoBehaviour, IPoolable<Vector3, Weapon, IMemoryPool>
{
    IMemoryPool _pool;
    PlayerWeapons _playerWeapon;

    public Weapon weapon;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        signalBus.Subscribe<InputStateSignalButtonE>(OnPressE);
        signalBus.Subscribe<InputStateSignalButtonQ>(OnPressQ);
    }

    private void OnPressE()
    {
        if (_playerWeapon != null)
        {
            _playerWeapon.SetWeaponRight(weapon);
            _pool.Despawn(this);
            _playerWeapon = null;
        }
    }

    private void OnPressQ()
    {
        if (_playerWeapon != null)
        {
            _playerWeapon.SetWeaponLeft(weapon);
            _pool.Despawn(this);
            _playerWeapon = null;
        }
    }

    public void OnDespawned()
    {
        _pool = null;
    }

    public void OnSpawned(Vector3 p1, Weapon p2, IMemoryPool p3)
    {
        transform.position = new Vector3(p1.x, 1, p1.z);
        weapon = p2;
        weapon.transform.SetParent(transform);
        weapon.transform.localScale = Vector3.one;
        p2.transform.localPosition = new Vector3();
        _pool = p3;
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerWeapons>();
        if (player != null)
        {
            _playerWeapon = player;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<PlayerWeapons>();
        if (player != null)
        {
            _playerWeapon = null;
        }
    }

    public class Factory : PlaceholderFactory<Vector3, Weapon, Loot>
    {

    }
}
