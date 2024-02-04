using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{

    private Health healthScript;

    [SerializeField] private Transform poisonParticles;
    // public List<int> pParticle = new List<int>();

    public List<int> burnTickTimers = new List<int>();

    void Start()
    {
        healthScript = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    //check if within sphere range
    public void CheckForDestructables()
    {
        Debug.Log("here");
        Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
        foreach(Collider c in colliders)
        {
            if(c.GetComponent<AOETarget>())
            {
                // c.GetComponent<AOETarget>().DealDamage();
                // Debug.Log("destroy object");
                ApplyBurn(4);
                Debug.Log("apply burn");
                Instantiate(poisonParticles, transform.position, Quaternion.Euler(90,0,0));
            }
        }
    }

    IEnumerator Burn()
    {
        // Instantiate(poisonParticles, transform.position, Quaternion.Euler(90,0,0));
        while(burnTickTimers.Count > 0)
        {
            for(int i = 0; i < burnTickTimers.Count; i++)
            {
                // poisonParticles = new Transform pParticle;
                // pParticle = 
                burnTickTimers[i]--;
            }
            healthScript.health -= 5;
            // => means in this case (remove number if number = 0) (boolean)
            burnTickTimers.RemoveAll(number => number == 0);
            yield return new WaitForSeconds(0.75f);
        }
        // Destroy(pParticle);
    }
}
