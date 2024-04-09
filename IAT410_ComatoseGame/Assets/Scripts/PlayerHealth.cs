using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float curHealth;
    public float maxHealth;
    public Slider healthBar;


    private bool startTime;
    public GameObject player;
    private float timeLeft = 3.0f;

    public AudioSource playerHitSFX;

    // Start is called before the first frame update
    void Awake()
    {
        curHealth = maxHealth;
        // Debug.Log("HERE");
        // healthBar.value = curHealth;
        healthBar.maxValue = maxHealth;

        healthBar.value = curHealth;
        playerHitSFX = GetComponents<AudioSource>()[2];
    }

    void Start()
    {
        // curHealth = maxHealth;
        // healthBar.value = curHealth;
        // healthBar.maxValue = maxHealth;

        startTime = false;
        player = GameObject.Find("PlayerArmature");
    }

    // Update is called once per frame
    void Update()
    {
        
        // //just for testing purposes
        // if(Input.GetKeyUp(KeyCode.E)){
        //     sendDamage(Random.Range(10,20));
        // }
    
        if(startTime)
        {
            timeLeft -= Time.deltaTime;
            Debug.Log(timeLeft);
            if(timeLeft <= 0 )
            {
                player.GetComponent<StarterAssets.ThirdPersonController>().setMoveSpeed(10);
                Debug.Log("speed returned");
                startTime = false;
                timeLeft = 3.0f;
            }
        }
    }

    public void sendDamage (float damageValue){
        
        Debug.Log("p hit by e, dmg : " + damageValue);
        curHealth -= damageValue;
        healthBar.value = curHealth;
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "enemyAttack"){
            playerHitSFX.Play();
            sendDamage(10);
            
            Debug.Log("test");

           // Destroy(other.collider.gameObject); // not working
           
            //try slow attack here 
            
        }
        if(other.collider.tag == "carnivalAttack")
        {
            playerHitSFX.Play();
            sendDamage(10);
            Debug.Log("speed decreased");
            this.GetComponent<StarterAssets.ThirdPersonController>().setMoveSpeed(5);
            startTime = true;
        }
                
    }

    public void addHealth(float healthValue){
        if(curHealth != maxHealth)
        {
            // Debug.Log("one" + healthValue);

            if((curHealth + healthValue) > maxHealth)
            {
                healthValue = (maxHealth - curHealth);
                Debug.Log(healthValue);
                curHealth += healthValue;
                healthBar.value = curHealth;
            }
            else if((curHealth + healthValue) <= maxHealth)
            {
                Debug.Log("gained : " + healthValue);
                curHealth += healthValue;
                healthBar.value = curHealth;
            }
            else{
                Debug.Log("full");
            }
        }
    }

    public void respawn(){
        curHealth = maxHealth;
        healthBar.value = curHealth;
    }

    public float checkHealth(){
        return curHealth;
    }

    public void upgradeHealth(float health)
    {
        maxHealth += health;
        Debug.Log(maxHealth);
    }
 
}
