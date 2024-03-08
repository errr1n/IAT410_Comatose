using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

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
    // public float immunityTimer;
    //boolean for whether power up is active
    public bool powerUp;

    // [SerializeField] private Volume volume;

    [SerializeField] private TMP_Text qPrompt;

    public float decreaseRate;


    void Awake()
    {
        // sets initial value to current kill count (0)
        immunityBar.value = curImmunity;
        // sets max kill value (from inspector)
        immunityBar.maxValue = maxImmunity;
        //sets powerup to false on awake
        powerUp = false;

        qPrompt.enabled = false;

    }

    void Update()
    {
        //if the current immunity is equal to maximum immunity
        if(curImmunity == maxImmunity)
        {
            qPrompt.enabled = true;
            //if immunity key pressed
            if (Input.GetKeyDown(KeyCode.Q))
            {
                //call the power up coroutine
                StartCoroutine(PowerUp());

                qPrompt.enabled = false;
            } 
        }
    }

    // called in enemy script
    public void AddKill()
    {
        //if immunity bar is not full
        if(curImmunity != maxImmunity && powerUp != true)
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
        // curImmunity = 0;
        // Debug.Log("Curr immunity = " + curImmunity);

        //update the value of the slider
        // immunityBar.value = curImmunity;
        powerUp = true;

        while(curImmunity > 0)
        {
            // powerUp = true;
            curImmunity -= (1/decreaseRate) / 10f;
            //if stamina is at full
            if(curImmunity < 0)
            {
                //set to full
                curImmunity = 0;
            }
            //update stamina bar UI
            immunityBar.value = curImmunity / maxImmunity;
            yield return new WaitForSeconds(0.1f);
        }

        //set power up to true
        // powerUp = true;
        // Debug.Log(powerUp);

        // if(volume.profile.TryGet(out Bloom bloom))
        // {
        //     bloom.intensity.value = 10f;
        // }

        //wait for specified time
        // yield return new WaitForSeconds(immunityTimer);
        // Debug.Log("POWER UP DONE");

        //set power up to false
        powerUp = false;
        // Debug.Log(powerUp);

        // if(volume.profile.TryGet(out Bloom bloomX))
        // {
        //     bloomX.intensity.value = 1f;
        // }
    }





    // //variable for current stamina
    // public float curStamina;
    // //variable for maximum stamina
    // public float maxStamina;
    // //access image for stamina bar
    // public Image Staminabar;
    // //how much stamina cost per attack
    // public float attackCost;
    // //rate at which stamina bar recharges
    // public float chargeRate;
    // //recharge coroutine variable
    // public Coroutine recharge;


    // //coroutine to recharge stamina bar
    // public IEnumerator RechargeStamina()
    // {
    //     //wait 1 second
    //     yield return new WaitForSeconds(1f);
    //     //while stamina is not full
    //     while(curStamina < maxStamina)
    //     {
    //         curStamina += chargeRate / 10f;
    //         //if stamina is at full
    //         if(curStamina > maxStamina)
    //         {
    //             //set to full
    //             curStamina = maxStamina;
    //         }
    //         //update stamina bar UI
    //         Staminabar.fillAmount = curStamina / maxStamina;
    //         yield return new WaitForSeconds(0.1f);
    //     }
    // }
}
