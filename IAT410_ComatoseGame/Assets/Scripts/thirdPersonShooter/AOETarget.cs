using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOETarget : MonoBehaviour
{
    // [SerializeField] private MeshRenderer targetMesh;
    private Health healthScript;

    public List<int> burnTickTimers = new List<int>();

    void Start()
    {
        healthScript = GetComponent<Health>();
    }

    // public void DealDamage()
    // {
        
    //     // Invoke(nameof(DestroySelf),2);
    //     StartCoroutine(Damage());
    // }

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

    // private IEnumerator Damage()
    // {
    //     // yield return new WaitForSeconds(2f);
    //     // Destroy(gameObject);

    // }

    // public void CheckIfBurnable()
    // {
    //     Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
    //     foreach(Collider c in colliders)
    //     {
    //         if(c.GetComponent<AOETarget>())
    //         {
    //            //  c.GetComponent<AOETarget>().DealDamage();
    //             c.GetComponent<AOETarget>().ApplyBurn(4);

    //            // Invoke(nameof(DestroyEnemy),0.5f);
    //             Debug.Log("destroy object");
    //         }
    //     }
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
