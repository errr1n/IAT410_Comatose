using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTakeDamage : MonoBehaviour
{
   
    

   public void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Player"){
            Destroy(gameObject);
        }
    }
 
}
