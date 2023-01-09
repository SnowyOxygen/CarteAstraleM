using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarObject
{
    public int ID;
    public Vector2 position;
    public float distance;
    public float orbitRadius;
    public Sprite icon;
    public Orbit orbit;
    public SolarObjectPreset preset;
    public string objectName;
    // obj name must be saved if renamed
    public bool renamedFlag = false;
    public float objectMass;
    public float objectRadius;
    public StarObject primary;

    public StarObject(Vector2 position, SolarObjectPreset preset, int ID, float distance = 0f, float orbitRadius = 0f, StarObject primary = null)
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

        objectMass = Random.Range(preset.massRange.x, preset.massRange.y);
        objectRadius = Random.Range(preset.radiusRange.x, preset.radiusRange.y);

        this.ID = ID;
    }
}
