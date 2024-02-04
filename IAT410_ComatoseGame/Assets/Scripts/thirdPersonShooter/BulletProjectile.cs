using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
   // [SerializeField] private Transform vfxHitGreen;
   // [SerializeField] private Transform vfxHitRed;

   [SerializeField] private float bulletSpeed;
   private Rigidbody bulletRigidbody;

   [SerializeField] private Transform poisonParticles;

   public ThirdPersonShooterController thirdPersonShooterController;

   public bool hitTarget;

   private void Awake()
   {
    bulletRigidbody = GetComponent<Rigidbody>();
   }

   private void Start()
   {
   //  float speed = 10f;
    bulletRigidbody.velocity = transform.forward * bulletSpeed;

   //  thirdPersonShooterController = GetComponent<ThirdPersonShooterController>();

   }

   private void OnTriggerEnter(Collider other)
   {
      if(other.GetComponent<StatusEffectManager>() != null)
      {

         // Instantiate(poisonParticles, transform.position, Quaternion.Euler(90,0,0));
         other.GetComponent<StatusEffectManager>().CheckForDestructables();
         //hit target (can play particles from here)
         //play particle effect (effet rotated 90 degrees))
         // Instantiate(poisonParticles, transform.position, Quaternion.Euler(90,0,0));
         // poisonParticles.transform.rotation = 90f;
         Debug.Log("green");

         // thirdPersonShooterController.CheckForDestructables();

         // StartCoroutine(AttackSequence());
         // CheckForDestructables();
         // Attack();
         // hitTarget = true;
         // Debug.Log(hitTarget);
         // StartCoroutine(thirdPersonShooterController.AttackSequence());
         // ThirdPersonShooterController.Attack();

         // Debug.Log("Destroy");
         // Attack();
      } else{
         // hit something else (can play particles from here)
         // Instantiate(vfxHitRed, transform.position, Quaternion.identity);
         Debug.Log("red");
         // Destroy(gameObject);
      }
      Destroy(gameObject);
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

   // //check if within sphere range
   //  private void CheckForDestructables()
   //  {
   //      Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
   //      foreach(Collider c in colliders)
   //      {
   //          if(c.GetComponent<AOETarget>())
   //          {
   //              c.GetComponent<AOETarget>().DealDamage();
   //              Debug.Log("destroy object");
   //          }
   //      }
   //  }
}
