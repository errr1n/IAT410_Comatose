using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health, maxHealth, curHealth;
    public GameObject healthPack, player;
    public Slider healthBar;

    public int pickupSpawnPercentage;

    public bool bossDead;
    ImmunityBar immunityBar;

    public AudioSource enemyHitSFX;
  
   
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
        enemyHitSFX = GetComponent<AudioSource>();
        
    }

    //check if the enemy is dead
    void Update()
    {
        
       
        //checks if the enmy is of type boss
        if(this.gameObject.name == "Boss")
        {
            if(curHealth <= maxHealth/2)
            {
                
                this.GetComponent<BossAINavPath>().IncreaseFireSpeed();
                
                Debug.Log("fire increased");
            } 
            if(curHealth <=0)
            {
                player.GetComponent<PlayerHealth>().upgradeHealth(10);
                bossDead = true;
                EnemyDeath();

               
            }
        } else {
            if(curHealth <=0){
                EnemyDeath();
                    }
        }
        
    }

    //OLD --- private void OnCollisionEnter(Collision collision){ (trigger in inspector was also not ticked on)
     private void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "PlayerAttack"){
            //other.GetComponent<player>().Damage();
            // Debug.Log("hit enemy");
            health-=1;
            enemyHitSFX.Play();
            sendDamage(6);
           // Destroy(gameObject);
            //need to destroy player projectile too 
           // this.GetComponent<AINavPath>().TakeDamage(1);
        }
    }

    //damage the enemy
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

    //on enemy death
    private void EnemyDeath()
    {
        //if its boss defeated - add to player maxHealth
       
            //destroy enemy
        Destroy(gameObject);
        
        

        

        //call addkill from immunity bar script
        immunityBar.AddKill();
        //debug kill amount
        Debug.Log("kills " + immunityBar.curImmunity);

        //random number between 1-10
        float randomNumber = Random.Range(0, 100);
        Debug.Log("random number: " + randomNumber);

        //if the random number is equal to 1 (10% chance)
        if(randomNumber <= pickupSpawnPercentage)
        {
            SpawnPickup();
        }
    }

    //spawn the health pickup
    private void SpawnPickup()
    {
        // transform.position = new Vector3(0, 0, 0);
        // print(transform.position.x);
        // here would generate a health pack

        Vector3 temp = transform.position;
        temp.y = 1;
        transform.position = temp;
        Instantiate(healthPack, transform.position, Quaternion.identity);
        // print(transform.position);
    }
}
