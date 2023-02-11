using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void Reload(){
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
