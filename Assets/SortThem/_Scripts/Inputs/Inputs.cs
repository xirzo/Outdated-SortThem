using System;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public event Action OnAttackInput;
    public InputActions InputActions { get; private set; }

    private void OnEnable()
    {
        InputActions.Enable();

        InputActions.Player.Attack.performed += ctx => OnAttackInput?.Invoke();
    }

    private void OnDisable()
    {
        InputActions.Player.Attack.performed -= ctx => OnAttackInput?.Invoke();

        InputActions.Disable();
    }
}
