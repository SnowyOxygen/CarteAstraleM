using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipPresenter : MonoBehaviour
{
    #region Singleton
    public static TooltipPresenter instance;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else{
            Debug.LogError("More than one instance of TooltipPresenter!");
        }
    }
    #endregion

    [SerializeField] private Text objClass;
    [SerializeField] private Text objMass;
    [SerializeField] private Text objRadius;
    [SerializeField] private Text objPosition;
    [SerializeField] private Text objName;
    [SerializeField] private Image objIcon;

    [SerializeField] private GameObject renameField;
    [SerializeField] private InputField renameInput;

    private StarObject starObject;

    private void Start() {
        renameField.SetActive(false);
    }

    public void UpdateTooltip(StarObject starObject){
        SolarObjectPreset preset = starObject.preset;
        this.starObject = starObject;

        objClass.text = $"Class : {preset.objClass}";
        objMass.text = $"Mass : {starObject.objectMass}";
        objRadius.text = $"Radius : {starObject.orbitRadius}";
        objPosition.text = $"Position : {starObject.position}";
        objName.text = starObject.objectName;

        if(preset.icon != null){
            objIcon.sprite = preset.icon;
        }

        Debug.Log($"Tooltip updated with {starObject.objectName}");
    }

    public void RenamingSubmit(){
        string newName = renameInput.text;

        if(newName != ""){
            starObject.objectName = newName;
            
            UpdateTooltip(starObject);

            SystemPresenter.instance.UpdatePresenters();

            ToggleRenaming();
        }
    }
    public void ToggleRenaming(){
        bool toggle = !renameField.activeSelf;

        renameField.SetActive(toggle);

        if(toggle){
            //TODO: add to escape list functionality
        }
        else{
            
        }
    }
}
