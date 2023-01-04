using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListElementPresenter : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Image icon;

    public void UpdateElement(string name, Sprite icon){
        text.text = name;
        if(icon != null) this.icon.sprite = icon;
    }
}
