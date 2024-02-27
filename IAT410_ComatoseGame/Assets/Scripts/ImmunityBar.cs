using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ImmunityBar : MonoBehaviour
{
    //variable for current immunity (number of kills)
    public float curImmunity;
    //variable for maximum immunity (number of kills)
    public float maxImmunity;
    //slider reference
    public Slider immunityBar;
    //public timer for length of power up
    public float immunityTimer;
    //boolean for whether power up is active
    public bool powerUp;

    // [SerializeField] private Volume volume;


    void Awake()
    {
        // sets initial value to current kill count (0)
        immunityBar.value = curImmunity;
        // sets max kill value (from inspector)
        immunityBar.maxValue = maxImmunity;
        //sets powerup to false on awake
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
                //call the power up coroutine
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

    private IEnumerator PowerUp()
    {
        // Debug.Log("POWER UP");

        //sets immunity bar back to 0
        curImmunity = 0;
        // Debug.Log("Curr immunity = " + curImmunity);

        //update the value of the slider
        immunityBar.value = curImmunity;

        //set power up to true
        powerUp = true;
        // Debug.Log(powerUp);

        // if(volume.profile.TryGet(out Bloom bloom))
        // {
        //     bloom.intensity.value = 10f;
        // }

        //wait for specified time
        yield return new WaitForSeconds(immunityTimer);
        // Debug.Log("POWER UP DONE");

        //set power up to false
        powerUp = false;
        // Debug.Log(powerUp);

        // if(volume.profile.TryGet(out Bloom bloomX))
        // {
        //     bloomX.intensity.value = 1f;
        // }
    }
}
