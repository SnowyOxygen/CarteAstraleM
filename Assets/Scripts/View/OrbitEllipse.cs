using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitEllipse : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Vector3[] points;
    public int segments = 64;

    public void ToggleEllipse(bool toggle)
    {
        lineRenderer.enabled = toggle;
    }
    public void GetEllipse(float scale, StarObject body, Orbit orbit)
    {
        points = new Vector3[segments + 1];

        for(int i = 0; i < segments; i++)
        {
            float angle = body.orbitRadius + ((float)i / (float)segments) * Mathf.PI * 2f;
            Vector2 point = orbit.GetPoint(body.distance, angle);
            points[i] = new Vector3(point.x, point.y, 0f) * scale;
        }
        points[segments] = points[0];

        lineRenderer.positionCount = segments + 1;
        lineRenderer.SetPositions(points);

        ToggleEllipse(false);
    }
}
