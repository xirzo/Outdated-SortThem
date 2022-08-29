using UnityEngine;

[RequireComponent(typeof(Inputs))]
public class HandMovement : MonoBehaviour
{
    private Inputs _input;

    private void OnEnable()
    {
        TryGetComponent(out _input);
    }
    private void Update()
    {
        TransformToCursor();
    }
    private void TransformToCursor()
    {
        transform.position = WorldMousePosition2D.GetMouseWorldPosition2D(_input.MousePosition);
    }
}
