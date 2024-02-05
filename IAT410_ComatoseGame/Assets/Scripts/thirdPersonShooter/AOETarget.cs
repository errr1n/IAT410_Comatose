using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOETarget : MonoBehaviour
{
    // [SerializeField] private MeshRenderer targetMesh;

    public void DealDamage()
    {
        
        // Invoke(nameof(DestroySelf),2);
        StartCoroutine(Damage());
    }

    private IEnumerator Damage()
    {
        // Instantiate(poisonParticles, transform.position, Quaternion.Euler(90,0,0))
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
