using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTeleportation : MonoBehaviour
{

    Camera cam; 
    TeleportationSpot teleportationSpot;
    public LayerMask teleportMask;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, teleportMask))
        {
            if(hit.collider.GetComponent<TeleportationSpot>()!= null)
            {
                teleportationSpot = hit.collider.GetComponent<TeleportationSpot>();
                teleportationSpot.m_Renderer.enabled = true;

                if(Input.GetMouseButtonDown(0))
                {
                    transform.position = teleportationSpot.target.position;
                }
            }
        }
    }
}
