using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Solar System", menuName = "presets/system", order = 2)]
public class SystemPreset : ScriptableObject
{
    public SolarObjectPreset star;
    public List<ObjectChoice> objectChoices = new List<ObjectChoice>();
    public Vector2Int planetCountRange;
}
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