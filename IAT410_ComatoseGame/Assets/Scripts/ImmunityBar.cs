using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ImmunityBar : MonoBehaviour
{
    //variable for current immunity (number of kills)
    public float curImmunity;
    //variable for maximum immunity (number of kills)
    public float maxImmunity;
    //slider reference
    public Slider immunityBar;

    public float immunityTimer;

    public bool powerUp;


    void Awake()
    {
        // sets initial value to current kill count (0)
        immunityBar.value = curImmunity;
        // sets max kill value (from inspector)
        immunityBar.maxValue = maxImmunity;

        powerUp = false;

    }

    void Update()
    {
        //if immunity key pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //if the current immunity is equal to maximum immunity
            if(curImmunity == maxImmunity)
            {
                //call the power up function
                StartCoroutine(PowerUp());
            } 
        }
    }

    // called in enemy script
    public void AddKill()
    {
        //if immunity bar is not full
        if(curImmunity != maxImmunity)
        {
            //add to immunity bar
            curImmunity++;
            //update the value of the slider
            immunityBar.value = curImmunity;
        }
    }

    //provides power up to player
    // private void PowerUp()
    // {
    //     Debug.Log("POWER UP");
    //     //sets immunity bar back to 0
    //     curImmunity = 0;
    //     //update the value of the slider
    //     immunityBar.value = curImmunity;
    // }

    private IEnumerator PowerUp()
    {
        Debug.Log("POWER UP");
        //sets immunity bar back to 0
        curImmunity = 0;
        Debug.Log("Curr immunity = " + curImmunity);
        //update the value of the slider
        immunityBar.value = curImmunity;

        //set power up to true
        powerUp = true;
        Debug.Log(powerUp);

        //wait for specified time
        yield return new WaitForSeconds(immunityTimer);

        
        Debug.Log("POWER UP DONE");

        //set power up to false
        powerUp = false;
        Debug.Log(powerUp);
    }
}
