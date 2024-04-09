using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEEnemyShot : MonoBehaviour
{

    [SerializeField] GameObject poisonParticle;
    GameObject pParticle;

    Vector3 bulletPosition;

  
    
    // Start is called before the first frame update
    void Start()
    {
        DelayDestroy();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Invoke(nameof(DestroyShot), 2f);
        
    }

    // private void OnTriggerEnter(Collider other)
    // {
      
    //     float timer;
    //     if(other.GetComponent<BulletTarget>() != null)
    //     {
    //         //hit target (can play particles from here)
    //         //play particle effect (effet rotated 90 degrees))
    //         pParticle = Instantiate(poisonParticle, transform.position, Quaternion.Euler(90,0,0));
    //         //destory particle after 3 seconds
    //         Destroy(pParticle, 3);
   
    //         // calls check if burnable method
    //         CheckIfBurnable();
    //     } 
    //     //destroy bullet
    //     Destroy(gameObject);
      
    // }

    private void OnCollisionEnter(Collision collision)
    {
        // ORIGINAL -----------------------
        // if(collision.collider.tag == "Player"){
        //     //other.GetComponent<player>().Damage();
        //     Debug.Log("hit player");
            
        //     //calls to the player health script and sends damage amount to update their healthbard
        //     // adjust as needed
        //     //collision.collider.GetComponent<PlayerHealth>().sendDamage(10);
        //     Destroy(this.gameObject);
        // }
        //----------------------------------


        float timer;
        if(collision.collider.tag == "isGround")
        {
            //hit target (can play particles from here)
            //play particle effect (effet rotated 90 degrees))
            pParticle = Instantiate(poisonParticle, transform.position, Quaternion.Euler(90,0,0));
            //destory particle after 3 seconds
            Destroy(pParticle, 3);
   
            // calls check if burnable method
            CheckIfBurnable();
           
            bulletPosition = transform.position;
            // Debug.Log(transform.position);
            Debug.Log("bullet position " + bulletPosition);
        } 
        //destroy bullet
        Destroy(gameObject);

        
    }

    //atm, this is only called once, it needs to be constantly called to check of an AOETarget is within the sphere
    private void CheckIfBurnable()
    {
        //creates a list of colliders and creates a 4m overlap sphere (sphere collider)
        Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
        foreach(Collider c in colliders)
        {
            //if their is an AOETarget script attached to object
            if(c.GetComponent<AOETarget>())
            {
            //apply the burn method to the object with the AOETarget script
            c.GetComponent<AOETarget>().ApplyBurn(4);

            // Debug.Log("Start Check");
            // c.GetComponent<AOETarget>().StartCheck();
            // c.GetComponent<AOETarget>().Test();
            }
        }
    }

//     private void OnTriggerEnter(Collider other)
//    {
      
//      float timer;
//       if(other.GetComponent<BulletTarget>() != null)
//       {
//          //hit target (can play particles from here)
//          //play particle effect (effet rotated 90 degrees))
//          pParticle = Instantiate(poisonParticle, transform.position, Quaternion.Euler(90,0,0));
//          //destory particle after 3 seconds
//          Destroy(pParticle, 3);
   
//          // calls check if burnable method
//          CheckIfBurnable();
//       } 
//       //destroy bullet
//       Destroy(gameObject);
      
//    }

    private void DelayDestroy()
    {
        Destroy(gameObject, 2f);
    }

//     public void DestroyShot(){
//         Destroy(gameObject);
//    }
}
