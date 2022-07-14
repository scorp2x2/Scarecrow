using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InputState
{
    public bool Left;
    public bool Right;
    public bool Forward;
    public bool Back;

    public float xMouse;
    public float yMouse;

    public bool ShootLeft;
    public bool ShootRight;
}
