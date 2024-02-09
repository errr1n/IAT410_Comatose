using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health, maxHealth, curHealth;
    public GameObject healthPack;
    public Slider healthBar;
   
    // Start is called before the first frame update
    // void Start()
    // {
    //    health = 3;
    // }
    void Start(){
         curHealth = maxHealth;
        healthBar.value = curHealth;
        healthBar.maxValue = maxHealth;
    }
    void Awake()
    {
        curHealth = maxHealth;
        healthBar.value = curHealth;
        healthBar.maxValue = maxHealth;

    }

    public void sendDamage (float damageValue){
        Debug.Log("dmg : " + damageValue);
        curHealth -= damageValue;
        healthBar.value = curHealth;
    }


    // Update is called once per frame
    void Update()
    {
        
        if(curHealth <=0){
            Destroy(gameObject);

            // here would generate a health pack
            Instantiate(healthPack, transform.position, Quaternion.identity);
        }
        
    }

    
     private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "PlayerAttack"){
            //other.GetComponent<player>().Damage();
            Debug.Log("hit enemy");
            health-=1;
            sendDamage(10);
           // Destroy(gameObject);
            //need to destroy player projectile too 
           // this.GetComponent<AINavPath>().TakeDamage(1);
        }
    }
}
