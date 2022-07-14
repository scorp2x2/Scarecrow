using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;

public class PlayerMoveHandler : ITickable
{
    Player _player;
    Settings _settings;
    InputState _inputState;

    public PlayerMoveHandler(Player player, Settings settings, InputState inputState)
    {
        _player = player;
        _settings = settings;
        _inputState = inputState;
    }

    public void Tick()
    {
        if (_inputState.Forward)
        {
            _player.Move(-Vector3.forward * _settings.SpeedMove * Time.deltaTime);
        }
        if (_inputState.Back)
        {
            _player.Move(-Vector3.back * _settings.SpeedMove * Time.deltaTime);
        }
        if (_inputState.Left)
        {
            _player.Move(-Vector3.left * _settings.SpeedMove * Time.deltaTime);
        }
        if (_inputState.Right)
        {
            _player.Move(-Vector3.right * _settings.SpeedMove * Time.deltaTime);
        }

        if (_inputState.xMouse != 0)
            _player.Rotate(new Vector3(0, _inputState.xMouse * _settings.SpeedRotation, 0));
        if (_inputState.yMouse != 0)
            _player.Rotate(new Vector3(-_inputState.yMouse * _settings.SpeedRotation, 0, 0));
    }

    [Serializable]
    public class Settings
    {
        public float SpeedMove;
        public float SpeedRotation;
    }
}
