using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem
{
    List<StarObject> starObjects;

    public SolarSystem(List<StarObject> starObjects)
    {
        this.starObjects = starObjects;
    }
}
