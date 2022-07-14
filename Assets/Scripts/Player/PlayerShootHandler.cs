using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class PlayerShootHandler : ITickable
{
    PlayerWeapons _playerWeapons;
    InputState _inputState;

    float timeLeftLastShoot;
    float timeRightLastShoot;

    public PlayerShootHandler(PlayerWeapons playerWeapons, InputState inputState)
    {
        _playerWeapons = playerWeapons;
        _inputState = inputState;
    }

    public void Tick()
    {
        if (_inputState.ShootLeft)
            if (_playerWeapons.leftWeapon)
                if (timeLeftLastShoot + _playerWeapons.leftWeapon.DelayShoot < Time.time)
                {
                    timeLeftLastShoot = Time.time;
                    _playerWeapons.leftWeapon.Shoot();
                }

        if (_inputState.ShootRight)
            if (_playerWeapons.rightWeapon)
                if (timeRightLastShoot + _playerWeapons.rightWeapon.DelayShoot < Time.time)
                {
                    timeRightLastShoot = Time.time;
                    _playerWeapons.rightWeapon.Shoot();
                }
    }
}
