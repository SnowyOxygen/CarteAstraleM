using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    #region Singleton
    public static SaveManager instance;

    private void Awake() {
        if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Debug.Log("Destroying extra instance of Save Manager");
            Destroy(gameObject);
        }
    }
    #endregion

    private SystemController systemController;

    private void Start()
    {
        systemController = SystemController.instance;

        // TODO: Check for flags
    }

    public void SaveSystem(){
        List<StarObject> toSave = systemController.GetObjects();

        SolarSystemModel model = SolarSystemAssembler.GetSolarSystemModel(
            toSave,
            systemController.seed);

        // TODO: save to new file
    }
    public void LoadSystem()
    {
        // TODO: load save from file & store in cache
        // TODO: reload scene
    }
}
