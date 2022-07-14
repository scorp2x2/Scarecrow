using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerWeapons : MonoBehaviour
{
    public Transform leftSlot;
    public Transform rightSlot;

    public Weapon leftWeapon;
    public Weapon rightWeapon;

    Loot.Factory _lootFactory;

    float timeSetWeapon;

    [Inject]
    public void Construct(Loot.Factory lootFactory, SignalBus signalBus, Gun.Factory weaponFactory)
    {
        _lootFactory = lootFactory;

        signalBus.Subscribe<InputStateSignalButtonE>(OnPressE);
        signalBus.Subscribe<InputStateSignalButtonQ>(OnPressQ);
    }

    private void OnPressE()
    {
        if (rightWeapon && timeSetWeapon + .1 < Time.time)
        {
            DropWeapon(rightWeapon, rightSlot.position);
            rightWeapon = null;
        }
    }

    private void OnPressQ()
    {
        if (leftWeapon && timeSetWeapon + .1 < Time.time)
        {
            DropWeapon(leftWeapon, leftSlot.position);
            leftWeapon = null;
        }
    }

    public void SetWeaponLeft(Weapon weapon)
    {
        if (leftWeapon)
            DropWeapon(leftWeapon, leftSlot.position);
        leftWeapon = weapon;
        SetWeapon(leftSlot, weapon);
    }

    public void SetWeaponRight(Weapon weapon)
    {
        if (rightWeapon)
            DropWeapon(rightWeapon, rightSlot.position);
        rightWeapon = weapon;
        SetWeapon(rightSlot, weapon);
    }

    void SetWeapon(Transform slot, Weapon weapon)
    {
        weapon.transform.SetParent(slot);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.rotation = new Quaternion();
        timeSetWeapon = Time.time;
    }

    void DropWeapon(Weapon weapon, Vector3 point)
    {
        SpawnLoot(weapon, point);
    }

    public void SpawnLoot(Weapon weapon, Vector3 point)
    {
        _lootFactory.Create(point, weapon);
    }
}
