using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SystemPresenter : MonoBehaviour
{
    #region Singleton
    public static SystemPresenter instance;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else{
            UnityEngine.Debug.LogWarning("More than one instance of System Presenter!");
            Destroy(gameObject);
        }
    }
    #endregion

    private List<StarObjectPresenter> objPresenters = new List<StarObjectPresenter>();
    private StarObjectPresenter starPresenter;
    private List<StarObject> currentObjects;
    [SerializeField] GameObject presenterPrefab;

    [SerializeField] private Text systemTitle;

    [Range(10f, 100f)] public float viewDistance = 20f;
    private float ratio; // To be multiplied with object's positions

    private void Start() {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        List<StarObject> starObjects = SystemController.instance.GetObjects();
        UpdatePresenters(starObjects);
        stopwatch.Stop();
        UnityEngine.Debug.Log($"System generated in {stopwatch.ElapsedMilliseconds} ms");
    }
    public void UpdatePresenters(List<StarObject> starObjects = null)
    {
        List<StarObject> objectList;

        if(starObjects == null) objectList = currentObjects;
        else{
            objectList = starObjects;
            currentObjects = starObjects;
        }

        ClearObjects();

        ratio = GetRatio(
            currentObjects.Select(x => x.distance).ToList()
        );

        foreach(StarObject starObj in currentObjects)
        {
            GameObject newObj = Instantiate(presenterPrefab, transform);
            StarObjectPresenter newPresenter = newObj.GetComponent<StarObjectPresenter>();
            newPresenter.UpdateObject(starObj.icon, starObj.position * ratio, ratio, starObj);
        }

        systemTitle.text = currentObjects[0].primary.objectName;

        //Update List
        ListPresenter.instance.UpdateList(currentObjects);
    }
    private float GetRatio(List<float> distances){
        return viewDistance / distances.Max(x => x);
    }
    private void ClearObjects()
    {
        foreach(StarObjectPresenter objPresenter in objPresenters)
        {
            Destroy(objPresenter.gameObject);
        }

        objPresenters.Clear();
    }
}
