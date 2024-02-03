using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOETarget : MonoBehaviour
{
    // [SerializeField] private MeshRenderer targetMesh;

    public void DealDamage()
    {
        Destroy(gameObject);
    }



}
