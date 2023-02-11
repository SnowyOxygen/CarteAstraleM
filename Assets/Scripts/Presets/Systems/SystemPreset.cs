using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

// Settings to be created that can be used in procedural generation for solar systems
[CreateAssetMenu(fileName = "New Solar System", menuName = "presets/system", order = 2)]
public class SystemPreset : ScriptableObject
{
    public SolarObjectPreset star;
    public List<ObjectChoice> objectChoices = new List<ObjectChoice>();
    public Vector2Int planetCountRange;
}

//TODO: make a generic weight choice object
[Serializable]
public struct SystemChoice{
    public int weight;
    public SystemPreset choice;

    public SystemChoice(int weight, SystemPreset choice)
    {
        this.weight = weight;
        this.choice = choice;
    }
}