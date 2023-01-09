using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPresenter : MonoBehaviour
{
    #region Singleton
    public static ListPresenter instance;
    
    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else{
            Debug.LogWarning("More than one instance of ListPresenter!");
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField] private GameObject listElementPrefab;

    private List<ListElementPresenter> listElements = new List<ListElementPresenter>();

    public void UpdateList(List<StarObject> planets){
        Clear();

        Debug.Log("Updating List");

        foreach(StarObject planet in planets){
            if(planet.primary != planet){
                GameObject newElement = Instantiate(listElementPrefab, transform);
                ListElementPresenter listElement = newElement.GetComponent<ListElementPresenter>();
                listElement.UpdateElement(planet.objectName, planet.icon);
                listElements.Add(listElement);
            }
            else continue;
        }
    }

    public void Clear(){
        foreach(ListElementPresenter element in listElements){
            Destroy(element.gameObject);
        }

        listElements.Clear();
    }
}
