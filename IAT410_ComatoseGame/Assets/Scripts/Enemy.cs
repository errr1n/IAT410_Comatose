using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health, maxHealth, curHealth;
    public GameObject healthPack;
    public Slider healthBar;

    ImmunityBar immunityBar;
   
    // Start is called before the first frame update
    // void Start()
    // {
    //    health = 3;
    // }
    void Start(){
        curHealth = maxHealth;
        healthBar.value = curHealth;
        healthBar.maxValue = maxHealth;

        //access immunity bar script from gameobject KCO
        immunityBar = GameObject.Find("KCO").GetComponent<ImmunityBar>();
    }
    void Awake()
    {
        curHealth = maxHealth;
        healthBar.value = curHealth;
        healthBar.maxValue = maxHealth;

    }

    public void sendDamage (float damageValue){
        // Debug.Log("dmg : " + damageValue);
        // Debug.Log("powerUp : " + immunityBar.powerUp);

        //checks if the power up is active from immunity bar script
        if(immunityBar.powerUp == true){

            //double the damage value of the players bullets (strength power up)
            curHealth -= (damageValue * 2);
            // Debug.Log("double damage = " + damageValue * 2);

            //update the enemy slider health bar
            healthBar.value = curHealth;
        }
        else{
            //deal the reguler damage value of the players bullets
            curHealth -= damageValue;
            // Debug.Log(damageValue);
            
            //update the enemy slider health bar
            healthBar.value = curHealth;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
        if(curHealth <=0){
            //destroy enemy
            Destroy(gameObject);

            //call addkill from immunity bar script
            immunityBar.AddKill();
            //debug kill amount
            Debug.Log("kills " + immunityBar.curImmunity);

            // here would generate a health pack
            Instantiate(healthPack, transform.position, Quaternion.identity);
        }
        
    }

    
     private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "PlayerAttack"){
            //other.GetComponent<player>().Damage();
            // Debug.Log("hit enemy");
            health-=1;
            sendDamage(10);
           // Destroy(gameObject);
            //need to destroy player projectile too 
           // this.GetComponent<AINavPath>().TakeDamage(1);
        }
    }
}
