using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles presenting objects that have been generated
public class StarObjectPresenter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer icon;
    [SerializeField] private Sprite placeholder;
    [SerializeField] private OrbitEllipse ellipse;
    private StarObject starObject;
    private Orbit orbit;
    
    public void UpdateObject(Sprite icon, Vector2 position, float scale, StarObject starObject)
    {
        if(icon != null)
        {
            this.icon.sprite = icon;
        }
        else{
            this.icon.sprite = placeholder;
        }

        transform.position = new Vector3(position.x, position.y, 0f);
        this.starObject = starObject;

        // Ellipse
        if(starObject.primary != starObject){
            ellipse.GetEllipse(scale, starObject, starObject.primary.orbit);
        }
    }
    private void OnMouseEnter() {
        ellipse.ToggleEllipse(true);
    }
    private void OnMouseExit() {
        ellipse.ToggleEllipse(false);
    }
    private void OnMouseDown() {
        // Update tooltip
        TooltipPresenter.instance.UpdateTooltip(starObject);

        // Activate selection
    }
}
