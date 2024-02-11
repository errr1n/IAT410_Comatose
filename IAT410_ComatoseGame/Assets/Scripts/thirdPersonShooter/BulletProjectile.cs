using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
   // [SerializeField] private Transform vfxHitGreen;
   // [SerializeField] private Transform vfxHitRed;

   [SerializeField] private float bulletSpeed;
   private Rigidbody bulletRigidbody;

   [SerializeField] GameObject poisonParticle;
   GameObject pParticle;

   // public ThirdPersonShooterController thirdPersonShooterController;

   private void Awake()
   {
    bulletRigidbody = GetComponent<Rigidbody>();
   }

   private void Start()
   {
    bulletRigidbody.velocity = transform.forward * bulletSpeed;
    DelayDestroy();
   }

   
   private void OnTriggerEnter(Collider other)
   {
      
     // float timer;
      if(other.GetComponent<BulletTarget>() != null)
      {
         //hit target (can play particles from here)
         //play particle effect (effet rotated 90 degrees))
         pParticle = Instantiate(poisonParticle, transform.position, Quaternion.Euler(90,0,0));
         //destory particle after 3 seconds
         Destroy(pParticle, 3);
   
         // calls check if burnable method
         CheckIfBurnable();
      } else
      {
         
      }
      //destroy bullet
      Destroy(gameObject);
      
   }


   //atm, this is only called once, it needs to be constantly called to check of an AOETarget is within the sphere
   private void CheckIfBurnable()
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

            // Debug.Log("Start Check");
            // c.GetComponent<AOETarget>().StartCheck();
            // c.GetComponent<AOETarget>().Test();
         }
      }
    }

   //if the bullet doesn't hit anything destroy it
   private void DelayDestroy()
   {
      Destroy(gameObject, 0.7f);
   }

   // youtube comments to delete bullets after a while
   // private void Update()
   // {
   //    public float timeRemaining = 5f;
   //    if(timeRemaining > 0)
   //    {
   //       timeRemaining -= Time.deltaTime;
   //    }
   //    else{
   //       Destroy(gameObject);
   //    }
   // }

   // private void Update()
   // {
   //    if(hitTarget = true)
   //    {
   //       Debug.Log("update attack");
   //       Attack();
   //    }
   // }

      // public void hitTarget()
      // {
      //    hitTarget = true;
      // }

   //  public void Attack()
   //  {
   //          //once attack button is pressed
   //          // Debug.Log("bullet attack");
   //          // StartCoroutine(AttackSequence());
   //          // Debug.Log("attack bottom");
   //          // poisonParticles.transform.position = gameObject.transform.position;
   //          // poisonParticles.SetActive(true);
   //          hitTarget = true;
   //  }

   //  private IEnumerator AttackSequence()
   //  {
   //       // poisonParticles.SetActive(true);
   //       Instantiate(poisonParticles, transform.position, Quaternion.Euler(90,0,0));
   //      yield return new WaitForSeconds(2f);
   //      Debug.Log("coroutine");
   //    //   poisonParticles.transform.position = gameObject.transform.position;
   //    //   poisonParticles.SetActive(true);
   //      CheckForDestructables();
   //      yield return new WaitForSeconds(1f);
   //    //   poisonParticles.SetActive(false);
   //       hitTarget = false;

   //       // Destroy(gameObject);
   //  }

}
