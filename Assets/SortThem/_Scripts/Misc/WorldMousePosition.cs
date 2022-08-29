using UnityEngine;

public static class WorldMousePosition2D
{
    public static Vector2 GetMouseWorldPosition2D(Vector2 mousePosition)
    {
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
    public static Vector2 GetMouseWorldPosition2D(Vector2 mousePosition, Camera camera)
    {
        return camera.ScreenToWorldPoint(mousePosition);
    }
}
