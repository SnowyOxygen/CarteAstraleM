using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles loading scenes from menu
public class SceneController : MonoBehaviour
{
    #region Singleton

    public static SceneController instance;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else{
            Debug.LogWarning("More than one instance of Scene Controller");
            Destroy(gameObject);
        }
    }

    #endregion

    // Reload current scene
    public void Reload(){
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
