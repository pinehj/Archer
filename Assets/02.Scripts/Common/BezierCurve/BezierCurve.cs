using Unity.VisualScripting;
using UnityEngine;

public class BezierCurve
{
    public static Vector2 CalcPosition(Vector2 startPos, Vector2 targetPos, float t, float yOffset)
    {
        Vector2 centerPos = (startPos + targetPos) / 2;
        centerPos.y += yOffset;

        Vector2 a = Vector2.LerpUnclamped(startPos, centerPos, t);
        Vector2 b = Vector2.LerpUnclamped(centerPos, targetPos, t);
        return Vector2.LerpUnclamped(a, b, t);
    }
}
