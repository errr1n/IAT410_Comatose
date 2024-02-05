using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOETarget : MonoBehaviour
{
    private Health healthScript;

    public List<int> burnTickTimers = new List<int>();

    void Start()
    {
        healthScript = GetComponent<Health>();
    }

    public void ApplyBurn(int ticks)
    {
        if(burnTickTimers.Count <= 0)
        {
            burnTickTimers.Add(ticks);
            StartCoroutine(Burn());
        }
        else
        {
            burnTickTimers.Add(ticks);
        }
    }

    // public void Test()
    // {
    //     Invoke(nameof(ApplyBurn(4)), 2);
    // }

    //check if in range
    //coroutine to wait a few seconds
    //do sphere check 
    //then apply damage

    private IEnumerator Burn()
    {
        while(burnTickTimers.Count > 0)
        {
            for(int i = 0; i < burnTickTimers.Count; i++)
            {
                burnTickTimers[i]--;
            }
            healthScript.health -= 5;
            burnTickTimers.RemoveAll(number => number == 0);
            yield return new WaitForSeconds(0.75f);
        }
        Destroy(gameObject);
    }

}
