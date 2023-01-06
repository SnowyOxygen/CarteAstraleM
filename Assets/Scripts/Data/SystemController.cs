using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    [SerializeField] private int seed;

    public List<StarObject> GetObjects(){
        if(star == null) GenerateSystem();

        List<StarObject> objects = planets;
        objects.Add(star);

        return objects;
    }
    public void GenerateSystem(int seed = -1){
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
    }
}
