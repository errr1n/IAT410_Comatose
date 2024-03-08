using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float curHealth;
    public float maxHealth;
    public Slider healthBar;


    // Start is called before the first frame update
    void Awake()
    {
        curHealth = maxHealth;
        // Debug.Log("HERE");
        // healthBar.value = curHealth;
        healthBar.maxValue = maxHealth;

        healthBar.value = curHealth;

    }

    void Start()
    {
        // curHealth = maxHealth;
        // healthBar.value = curHealth;
        // healthBar.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        // //just for testing purposes
        // if(Input.GetKeyUp(KeyCode.E)){
        //     sendDamage(Random.Range(10,20));
        // }
    
        
    }

    public void sendDamage (float damageValue){
        Debug.Log("p hit by e, dmg : " + damageValue);
        curHealth -= damageValue;
        healthBar.value = curHealth;
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "enemyAttack"){
            sendDamage(10);
            Debug.Log("collided with player");
           // Destroy(other.collider.gameObject); // not working
            
            
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
 
}
