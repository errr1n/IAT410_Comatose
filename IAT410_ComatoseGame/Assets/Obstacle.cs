using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float health;
    
    public void OnCollisionEnter(Collision collision){
        if(collision.collider.tag == "Obstacle"){
        
            Destroy(gameObject);
            // Destroy(collision.gameObject);
           

   
        }
    }

    
}
