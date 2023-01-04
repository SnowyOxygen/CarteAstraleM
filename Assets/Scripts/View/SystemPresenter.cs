using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SystemPresenter : MonoBehaviour
{
    private List<StarObjectPresenter> objPresenters = new List<StarObjectPresenter>();
    private StarObjectPresenter starPresenter;
    [SerializeField] GameObject presenterPrefab;

    [SerializeField] private Text systemTitle;

    [Range(10f, 100f)] public float viewDistance = 20f;
    private float ratio; // To be multiplied with object's positions

    private void Start() {
        List<StarObject> starObjects = SystemController.instance.GetObjects();
        UpdatePresenters(starObjects);
    }
    public void UpdatePresenters(List<StarObject> starObjects)
    {
        ClearObjects();

        ratio = GetRatio(
            starObjects.Select(x => x.distance).ToList()
        );

        foreach(StarObject starObj in starObjects)
        {
            GameObject newObj = Instantiate(presenterPrefab, transform);
            StarObjectPresenter newPresenter = newObj.GetComponent<StarObjectPresenter>();
            newPresenter.UpdateObject(starObj.icon, starObj.position * ratio, ratio, starObj);
        }

        systemTitle.text = starObjects[0].primary.objectName;

        //Update List
        ListPresenter.instance.UpdateList(starObjects);
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
