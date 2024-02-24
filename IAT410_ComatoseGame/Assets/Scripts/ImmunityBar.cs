using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ImmunityBar : MonoBehaviour
{
    // public Text counterText;
    // public int kills;

    public float curImmunity;
    public float maxImmunity;
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(curImmunity == maxImmunity)
            {
                PowerUp();
            } 
        }
    }

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

    private void PowerUp()
    {
        Debug.Log("POWER UP");
        curImmunity = 0;
        immunityBar.value = curImmunity;
    }
}
