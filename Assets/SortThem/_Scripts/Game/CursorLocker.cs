using UnityEngine;

public class CursorLocker : MonoBehaviour
{
    [SerializeField] private CursorLockMode _lockState;
    [SerializeField] private bool _isVisible;

    private void OnValidate()
    {
        SetCursorLock();
        SetCursorVisibility();
    }

    private void SetCursorLock()
    {
        Cursor.lockState = _lockState;
    }

    private void SetCursorVisibility()
    {
        Cursor.visible = _isVisible;
    }
}
