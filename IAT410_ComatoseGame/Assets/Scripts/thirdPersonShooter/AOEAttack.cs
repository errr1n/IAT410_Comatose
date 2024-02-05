using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEAttack : MonoBehaviour
{
    // private BulletProjectile bulletProjectile;
    // [SerializeField] private Transform poisonParticles;

    // Start is called before the first frame update
    // void Start()
    // {
    //     bulletProjectile = GetComponent<BulletProjectile>();
    // }

    // Update is called once per frame
    // void Update()
    // {
    //     if(bulletProjectile.hitTarget = true)
    //   {
    //      Debug.Log("update attack");
    //      Attack();
    //   }
    // }

    // private void Attack()
    // {
    //         //once attack button is pressed
    //         Debug.Log("bullet attack");
    //         StartCoroutine(AttackSequence());
    //         Debug.Log("attack bottom");
    //         // poisonParticles.transform.position = gameObject.transform.position;
    //         // poisonParticles.SetActive(true);
    // }

    // private IEnumerator AttackSequence()
    // {
    //      // poisonParticles.SetActive(true);
    //      Instantiate(poisonParticles, transform.position, Quaternion.Euler(90,0,0));
    //     yield return new WaitForSeconds(1f);
    //     Debug.Log("coroutine");
    //   //   poisonParticles.transform.position = gameObject.transform.position;
    //   //   poisonParticles.SetActive(true);
    //     CheckForDestructables();
    //     yield return new WaitForSeconds(1f);
    //   //   poisonParticles.SetActive(false);
    //      bulletProjectile.hitTarget = false;
    // }

    // private void CheckForDestructables()
    // {
    //     Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
    //     foreach(Collider c in colliders)
    //     {
    //         if(c.GetComponent<AOETarget>())
    //         {
    //             c.GetComponent<AOETarget>().DealDamage();
    //             Debug.Log("destroy object");
    //         }
    //     }
    // }
}
