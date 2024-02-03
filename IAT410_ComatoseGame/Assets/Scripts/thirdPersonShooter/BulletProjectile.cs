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

   private void Awake()
   {
    bulletRigidbody = GetComponent<Rigidbody>();
   }

   private void Start()
   {
   //  float speed = 10f;
    bulletRigidbody.velocity = transform.forward * bulletSpeed;
   }

   private void OnTriggerEnter(Collider other)
   {
      if(other.GetComponent<BulletTarget>() != null)
      {
         //hit target (can play particles from here)
         Instantiate(poisonParticles, transform.position, Quaternion.identity);
         // poisonParticles.transform.rotation = 180;
         Debug.Log("green");
         Debug.Log("Destroy");
         // Attack();
      } else{
         // hit something else (can play particles from here)
         // Instantiate(vfxHitRed, transform.position, Quaternion.identity);
         Debug.Log("red");
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

   //  private void Attack()
   //  {
   //          //once attack button is pressed
   //          Debug.Log("bullet attack");
   //          // StartCoroutine(AttackSequence());
   //          // poisonParticles.transform.position = gameObject.transform.position;
   //          poisonParticles.SetActive(true);
   //  }

   //  private IEnumerator AttackSequence()
   //  {
   //      yield return new WaitForSeconds(0.25f);
   //      Debug.Log("coroutine");
   //      poisonParticles.transform.position = gameObject.transform.position;
   //      poisonParticles.SetActive(true);
   //      CheckForDestructables();
   //      yield return new WaitForSeconds(1f);
   //      poisonParticles.SetActive(false);
   //  }

   //  private void CheckForDestructables()
   //  {
   //      Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
   //      foreach(Collider c in colliders)
   //      {
   //          if(c.GetComponent<AOETarget>())
   //          {
   //              c.GetComponent<AOETarget>().DealDamage();
   //          }
   //      }
   //  }
}
