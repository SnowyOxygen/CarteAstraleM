using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DTO for stellar objects.
/// </summary>
public class StarObject
{
    public Vector2 position;
    public float distance;
    public float orbitRadius;
    public Sprite icon;
    public Orbit orbit;
    public SolarObjectPreset preset;
    public string objectName;
    public float objectMass;
    public StarObject primary;

    public StarObject(Vector2 position, SolarObjectPreset preset, float distance = 0f, float orbitRadius = 0f, StarObject primary = null)
    {
        this.distance = distance;
        this.position = position;
        this.preset = preset; 
        if(primary == null){
            this.primary = this;
            objectName = NameGenerator.GenerateStarName();
        }
        else this.primary = primary;
        icon = preset.icon;
        orbit = Orbit.RandomOrbit();
    }
}
