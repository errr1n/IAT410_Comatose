using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOETarget : MonoBehaviour
{
    // [SerializeField] private MeshRenderer targetMesh;

    public void DealDamage()
    {
        
        Invoke(nameof(DestroySelf),2);
    }

    public void DestroySelf(){
        Destroy(gameObject);
    }

}
