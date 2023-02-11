using System.Collections.Generic;
using System;

[Serializable]
public class SolarSystemModel
{
    public string Name { get; set; }
    public int Seed { get; set; }
    // Objects that have been renamed
    public List<SolarObjectModel> SolarObjects { get; set; }
}
