using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Manages & creates data for solar systems & objects
public class SystemController : MonoBehaviour
{
    #region Singleton
    public static SystemController instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("More than one instance of System Controller");
        }
        else{
            instance = this;
        }
    }
    #endregion

    [SerializeField] List<SystemChoice> presets;

    private StarObject star;
    private List<StarObject> planets = new List<StarObject>();

    private SolarSystemModel save;
    // private SolarSystemModel save = new SolarSystemModel{
    //     Name = "test system",
    //     Seed = 4019802,
    //     SolarObjects = new List<SolarObjectModel>(){
    //         new SolarObjectModel{
    //             Order = 1,
    //             Name = "Venus"
    //         },
    //         new SolarObjectModel{
    //             Order = 3,
    //             Name = "Jupiter"
    //         }
    //     }
    // };

    public int seed;

    public List<StarObject> GetObjects(){
        // Check if save was selected
        if(save != null){
            seed = save.Seed;
        }
        else seed = Random.Range(0, 1000000000);

        // Generate new system if doesn't exist
        if(star == null) GenerateSystem(seed);

        List<StarObject> objects = new List<StarObject>{ star };
        objects.AddRange(planets);

        return objects;
    }

    // Generate system from preset & seed
    public void GenerateSystem(int seed){
        // Use seed
        if(seed == -1){
            this.seed = Random.Range(0, 1000000000);
            Random.InitState(this.seed);
            Debug.Log($"Creating system with seed {seed}");
        }
        else{
            this.seed = seed;
            Random.InitState(this.seed);
            Debug.Log($"Creating system with seed {seed}");
        }

        // Get random system
        SystemPreset systemChoice = presets[
            Probability.GetChoice(presets.Select(x => x.weight).ToList())
        ].choice;

        // Get star
        star = new StarObject(Vector2.zero, systemChoice.star, 0);
        Debug.Log($"Star generated with name {star.objectName}");
        
        // Get planets
        planets.Clear();

        Vector2Int range = systemChoice.planetCountRange;
        int limit = Random.Range(range.x, range.y);

        List<string> planetNames = NameGenerator.GetPlanetNames(star.objectName, limit);

        List<ObjectChoice> planetChoices = systemChoice.objectChoices;

        for(int i = 0; i < limit; i++){
            SolarObjectPreset planetChoice = planetChoices[
                Probability.GetChoice(planetChoices.Select(x => x.weight).ToList())
            ].choice;

            float distance = Random.Range(10f, 100f);
            float radiusDistance = Random.Range(0f, 2 * Mathf.PI);
            Vector2 position = star.orbit.GetPoint(distance, radiusDistance);

            StarObject newPlanet = new StarObject(
                position, planetChoice, i + 1, distance, radiusDistance, star
            );

            newPlanet.objectName = planetNames[i];
            Debug.Log($"Object generated with name {newPlanet.objectName}");

            planets.Add(newPlanet);
        }

        RenameObjects();
    }

    // Apply save changes to system
    public void RenameObjects(){
        if(save != null){
            List<SolarObjectModel> objects = save.SolarObjects;
            
            foreach(SolarObjectModel model in objects){
                int index = model.Order;
                if(index == 0){
                    star.objectName = model.Name;
                    continue;
                }
                if(index < planets.Count){
                    planets[index].objectName = model.Name;
                }
            }
        }
    }
}
