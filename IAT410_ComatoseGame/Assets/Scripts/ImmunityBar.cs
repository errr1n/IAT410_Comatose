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


    void Awake()
    {
        // sets initial value to current kill count (0)
        immunityBar.value = curImmunity;
        // sets max kill value (from inspector)
        immunityBar.maxValue = maxImmunity;

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
                PowerUp();
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
    private void PowerUp()
    {
        Debug.Log("POWER UP");
        //sets immunity bar back to 0
        curImmunity = 0;
        //update the value of the slider
        immunityBar.value = curImmunity;
    }
}
