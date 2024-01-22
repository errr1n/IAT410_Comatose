using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationSpot : MonoBehaviour
{

    [HideInInspector]
    public Transform target;
    [HideInInspector]
    public MeshRenderer m_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponentInChildren<Transform>();
        m_Renderer = GetComponent<MeshRenderer>();
    }

   
}
