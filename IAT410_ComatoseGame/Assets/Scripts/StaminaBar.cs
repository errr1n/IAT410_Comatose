using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


public class StaminaBar : MonoBehaviour
{
    //variable for current immunity (number of kills)
    public float curStamina;
    //variable for maximum immunity (number of kills)
    public float maxStamina;
 
    public Image Staminabar;

    public float attackCost;

    public float chargeRate;

    public Coroutine recharge;

    public IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(1f);

        while(curStamina < maxStamina)
        {
            curStamina += chargeRate / 10f;

            if(curStamina > maxStamina)
            {
                curStamina = maxStamina;
            }

            Staminabar.fillAmount = curStamina / maxStamina;
            yield return new WaitForSeconds(0.1f);
        }
    }

}
