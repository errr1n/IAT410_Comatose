using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
   [SerializeField] private Transform vfxHitGreen;
   [SerializeField] private Transform vfxHitRed;

   [SerializeField] private float bulletSpeed;
   private Rigidbody bulletRigidbody;

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
         // Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
         Debug.Log("green");
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
}
