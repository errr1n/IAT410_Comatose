using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectileRaycast : MonoBehaviour
{
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;

    private Vector3 targetPosition;

    public void Setup(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    private void Update()
    {
        float distanceBefore = Vector3.Distance(transform.position, targetPosition);

        Vector3 moveDir = (targetPosition - transform.position).normalized;
        float moveSpeed = 200f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        float distanceAfter = Vector3.Distance(transform.position, targetPosition);

        if(distanceBefore < distanceAfter)
        {
            // red particles
            // Instantiate(vfxHitRed, targetPosition, Quaternion.identity)
            Debug.Log("new red");
            transform.Find("Trail").SetParent(null);
            Destroy(gameObject);
           // Invoke(nameof(DestroySelf),0.5f);
        }
    }

}
