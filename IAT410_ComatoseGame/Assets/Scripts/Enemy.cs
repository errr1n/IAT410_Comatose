using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectile;

    
    public float health;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        

        if(health <1){
            
            Destroy(gameObject);
        }
        
    }

    public void OnCollisionEnter(Collision collision){
        if(collision.collider.tag == "projectile"){
            //collide with player projectile
            health -=1;
            Destroy(collision.gameObject);
            
        }
    }
}
