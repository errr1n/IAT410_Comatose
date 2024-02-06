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
        healthBar.value = curHealth;
        healthBar.maxValue = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        
        //just for testing purposes
        if(Input.GetKeyUp(KeyCode.E)){
            sendDamage(Random.Range(10,20));
        }
    
        
    }

    public void sendDamage (float damageValue){
        Debug.Log("dmg : " + damageValue);
        curHealth -= damageValue;
        healthBar.value = curHealth;
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "enemyAttack"){
            //sendDamage(Random.Range(10,20));
            Debug.Log("collided with player");
           // Destroy(other.collider.gameObject); // not working
            
            
        }
    }

 
}
