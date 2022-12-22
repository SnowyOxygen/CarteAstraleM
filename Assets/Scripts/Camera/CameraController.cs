using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Receive player input and apply changes to camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    private Camera cam;

    private Vector3 origin;
    private Vector3 difference;
    private bool drag = false;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        Pan();
    }

    private void Pan()
    {
        if (Input.GetMouseButton(2))
        {
            difference = (cam.ScreenToWorldPoint(Input.mousePosition)) - cam.transform.position;

            if (!drag)
            {
                drag = true;
                origin = cam.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

        if (drag)
        {
            cam.transform.position = origin - difference;
        }
    }
}
