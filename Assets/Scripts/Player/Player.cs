using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player
{
    CharacterController _characterController;
    Camera _camera;

    public Player(CharacterController characterController, Camera camera)
    {
        _characterController = characterController;
        _camera = camera;
    }

    public void Move(Vector3 vector)
    {
        _characterController.Move(_characterController.transform.TransformDirection(vector));
    }

    public void Rotate(Vector3 vector)
    {
        _characterController.transform.localRotation = Quaternion.Euler(_characterController.transform.localRotation.eulerAngles + Vector3.up * vector.y);
        _camera.transform.localRotation = Quaternion.Euler(_camera.transform.localRotation.eulerAngles + Vector3.right * vector.x);
    }
}
