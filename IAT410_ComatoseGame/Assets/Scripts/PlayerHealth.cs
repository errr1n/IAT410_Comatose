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
    void Start()
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
        curHealth -= damageValue;
        healthBar.value = curHealth;
    }
}
