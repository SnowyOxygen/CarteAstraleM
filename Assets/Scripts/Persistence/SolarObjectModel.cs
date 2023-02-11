using System;

// Data model for solar object to be saved
[Serializable]
public class SolarObjectModel
{
    // Order in which planet spawned in
    public int Order { get; set; }
    // Name given by player
    public string Name { get; set; }
}
