using System;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public event Action OnAttackInput;

    public Vector2 MousePosition { get; private set; }
    public InputActions InputActions { get; private set; }

    private void OnEnable()
    {
        InputActions = new InputActions();
        InputActions.Enable();

        InputActions.Player.Attack.performed += ctx => OnAttackInput?.Invoke();
    }
    private void Update()
    {
        MousePosition = InputActions.Player.Look.ReadValue<Vector2>();
    }
    private void OnDisable()
    {
        InputActions.Player.Attack.performed -= ctx => OnAttackInput?.Invoke();

        InputActions.Disable();
    }
}
