using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Solar Object", menuName = "presets/solarObj", order = 1)]
public class SolarObjectPreset : ScriptableObject
{
    public Sprite icon;
    public string objClass;
    public Vector2 massRange;
    public Vector2 radiusRange;
}
[Serializable]
public struct ObjectChoice
{
    public int weight;
    public SolarObjectPreset choice;

    public ObjectChoice(int weight, SolarObjectPreset choice)
    {
        this.weight = weight;
        this.choice = choice;
    }
}