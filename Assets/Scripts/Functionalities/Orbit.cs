using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Data model for orbit parameters
public class Orbit
{
    public float bias;
    public float masterAngle;
    public float k;

    public Orbit(float b, float angle)
    {
        bias = b;
        masterAngle = angle;
        k = Mathf.Sqrt(1 - Mathf.Pow(bias, 2));
    }

    public static Orbit RandomOrbit()
    {
        return new Orbit(Random.Range(0.5f, 1f), Random.Range(0, Mathf.PI * 2));
    }

    // Returns a 2D point in space around an orbit
    public Vector2 GetPoint(float distance, float orbitRadians)
    {
        //TODO: seperate point generation from data model
        Vector2 newPoint;

        float j = bias * Mathf.Sin(orbitRadians) * distance;
        float l = distance * Mathf.Sin(masterAngle);
        float m = distance * Mathf.Cos(masterAngle);

        float x = Mathf.Cos(orbitRadians) * m - j * Mathf.Sin(masterAngle) + k * m;
        float y = j * Mathf.Cos(masterAngle) + l * (Mathf.Cos(orbitRadians) + k);

        newPoint = new Vector2(x, y);

        return newPoint;
    }
}
