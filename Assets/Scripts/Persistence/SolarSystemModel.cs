using System.Collections.Generic;
using System;

// Data model for solar systems to be saved
[Serializable]
public class SolarSystemModel
{
    public string Name { get; set; }
    public int Seed { get; set; }
    // Objects that have been renamed
    public List<SolarObjectModel> SolarObjects { get; set; }
}
