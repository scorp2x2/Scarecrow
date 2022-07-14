using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputSystem : MonoBehaviour
{
    InputState _inputState;
    SignalBus _signalBus;

    [Inject]
    public void Construct(InputState inputState, SignalBus signalBus)
    {
        _inputState = inputState;
        _signalBus = signalBus;
    }

    public void OnLeft(InputValue input)
    {
        _inputState.Left = input.isPressed;
    }

    public void OnRight(InputValue input)
    {
        _inputState.Right = input.isPressed;
    }

    public void OnForward(InputValue input)
    {
        _inputState.Forward = input.isPressed;
    }

    public void OnBack(InputValue input)
    {
        _inputState.Back = input.isPressed;
    }

    public void OnQ(InputValue input)
    {
        _signalBus.Fire<InputStateSignalButtonQ>();
    }

    public void OnE(InputValue input)
    {
        _signalBus.Fire<InputStateSignalButtonE>();
    }

    public void OnLMC(InputValue input)
    {
        _inputState.ShootLeft = input.isPressed;
    }

    public void OnRMC(InputValue input)
    {
        _inputState.ShootRight = input.isPressed;
    }

    public void OnR(InputValue input)
    {
        _signalBus.Fire<InputStateSignalButtonR>();
    }

    void Update()
    {
        _inputState.xMouse = Input.GetAxis("Mouse X");
        _inputState.yMouse = Input.GetAxis("Mouse Y");
    }
}
