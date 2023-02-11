using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Handles presenting the menu & detects the escape key
public class MenuPresenter : MonoBehaviour
{
    #region Singleton

    public static MenuPresenter instance;

    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else{
            Debug.LogWarning("More than one instance of Menu Presenter");
            Destroy(gameObject);
        }
    }

    #endregion

    private Stack<Action> escapeActions = new Stack<Action>();
    [SerializeField] private GameObject menuPanel;

    private void Start() {
        menuPanel.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) Escape(); 
    }

    private void Escape(){
        if(escapeActions.Count > 0){
            Action action = escapeActions.Pop();

            action.Invoke();
            return;
        }

        EscapeMenuToggle();
    }

    public void AddAction(Action action){
        escapeActions.Push(action);
    }

    private void EscapeMenuToggle(){
        //TODO: toggle menu
        bool toggle = menuPanel.activeSelf;

        menuPanel.SetActive(!toggle);
    }
}
