using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
   
    // Start is called before the first frame update
    void Start()
    {
       health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(health <=0){
            Destroy(gameObject);
        }
        
    }

    
     private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "PlayerAttack"){
            //other.GetComponent<player>().Damage();
            Debug.Log("hit enemy");
            health-=1;
           // Destroy(gameObject);
            //need to destroy player projectile too 
           // this.GetComponent<AINavPath>().TakeDamage(1);
        }
    }
}
