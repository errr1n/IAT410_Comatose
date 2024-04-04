using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class StaminaBar : MonoBehaviour
{
    //variable for current stamina
    public float curStamina;
    //variable for maximum stamina
    public float maxStamina;
    //access image for stamina bar
    public Image Staminabar;
    //how much stamina cost per attack
    public float attackCost;
    //rate at which stamina bar recharges
    public float chargeRate;
    //recharge coroutine variable
    public Coroutine recharge;


    //coroutine to recharge stamina bar
    public IEnumerator RechargeStamina()
    {
        //wait 1 second
        yield return new WaitForSeconds(0.5f);
        //while stamina is not full
        while(curStamina < maxStamina)
        {
            curStamina += chargeRate / 10f;
            //if stamina is at full
            if(curStamina > maxStamina)
            {
                //set to full
                curStamina = maxStamina;
            }
            //update stamina bar UI
            Staminabar.fillAmount = curStamina / maxStamina;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
