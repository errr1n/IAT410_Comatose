using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOETarget : MonoBehaviour
{
    //access health script
    // private Health healthScript;
    //access player health script
    private PlayerHealth playerhealth;

    public bool canBurn;

    //list to countdown # of ticks of damage
    public List<int> burnTickTimers = new List<int>();

    void Start()
    {
        //get health component (so it get be lowered on tick)
        // healthScript = GetComponent<Health>();
        playerhealth = GetComponent<PlayerHealth>();

        canBurn = false;
    }

    void Update()
    {
        // if(canBurn = true)
        // {
            // ApplyBurn(4);
            CheckIfBurnable();
        // }
    }

    //apply burn for specified number of ticks
    public void ApplyBurn(int ticks)
    {
        //if burn counter is lower or = to 0 (makes sure the damage doesn't stack)
        if(burnTickTimers.Count <= 0)
        {
            //add # ticks to burnTimer list
            burnTickTimers.Add(ticks);
            //start coroutine (timer)
            StartCoroutine(Burn());
        }
        else
        {
            //add # ticks to burnTimer list (else is needed so burn damage doesn't stack)
            burnTickTimers.Add(ticks);
        }
    }

    //WHAT NEEDS TO HAPPEN v
    //check if in range of sphere (cuurently done in CheckIfBurnable() in BulletProjectile script)
    //coroutine to wait a few seconds (optional, but good to give the player time to relax)
    //do sphere check (needs to be a constant check to make sure they're still within sphere range)
    //then apply damage (aka ApplyBurn;) (although looking at it now, may not need to be in a list with a countdown if it's constantly checking in within sphere, damage can just be done in the same code)

    private void CheckIfBurnable()
    {
        if(canBurn = true)
        {
        //creates a list of colliders and creates a 4m overlap sphere (sphere collider)
        Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
        foreach(Collider c in colliders)
        {
            //if their is an AOETarget script attached to object
            if(c.GetComponent<AOETarget>())
            {
            //apply the burn method to the object with the AOETarget script
            c.GetComponent<AOETarget>().ApplyBurn(4);
            // Debug.Log("apply burn 1");

            // Debug.Log("Start Check");
            // c.GetComponent<AOETarget>().StartCheck();
            // c.GetComponent<AOETarget>().Test();
            }
        }
        }
        canBurn = false;
    }

    public void CanBurn()
    {
        canBurn = true;
    }

    // burn coroutine (timer)
    private IEnumerator Burn()
    {
        //add delay here so it doesnt start right away?

        //while there are ticks in the burntimer list
        while(burnTickTimers.Count > 0)
        {
            // //creates a list of colliders and creates a 4m overlap sphere (sphere collider)
            // Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
            // foreach(Collider c in colliders)
            // {
            //     //if their is an AOETarget script attached to object
            //     if(c.GetComponent<AOETarget>())
            //     {
            //     //apply the burn method to the object with the AOETarget script
            //     // StartCoroutine(Delay());
            //     // Debug.Log("NEW COROUTINE");
            //     c.GetComponent<AOETarget>().ApplyBurn(4);
            //     // c.GetComponent<AOETarget>().StartCheck();
            //     // c.GetComponent<AOETarget>().Test();
            //     }
            // }

            //for every item in burntimer list
            for(int i = 0; i < burnTickTimers.Count; i++)
            {
                //remove 1 from list
                burnTickTimers[i]--;
            }
            //subtract 5 health per tick (seperate health script)
            // healthScript.health -= 5;
            //player health
            playerhealth.sendDamage(5);
            //delete the list when it gets down to 0
            burnTickTimers.RemoveAll(number => number == 0);
            //wait 0.75seconds (time between ticks)
            yield return new WaitForSeconds(0.75f);
        }
        //just for testing won't destroy only damage 
        // Destroy(gameObject);
    }

    // public void StartCheck()
    // {
    //   //creates a list of colliders and creates a 4m overlap sphere (sphere collider)
    //   Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
    //   foreach(Collider c in colliders)
    //   {
    //      //if their is an AOETarget script attached to object
    //      if(c.GetComponent<AOETarget>())
    //      {
    //         //apply the burn method to the object with the AOETarget script
    //         StartCoroutine(DelayedAction());
    //         Debug.Log("NEW COROUTINE");
    //         c.GetComponent<AOETarget>().ApplyBurn(4);
    //         // c.GetComponent<AOETarget>().StartCheck();
    //         // c.GetComponent<AOETarget>().Test();
    //      }
    //   }
    // }

    // private IEnumerator DelayedAction()
    // {
    //     Debug.Log("Delay");
    //     yield return new WaitForSeconds(3f);
    //     Debug.Log("Delay2");
    // }

}
