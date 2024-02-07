using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    Vector3 vectorPoint;
    [SerializeField] private List<GameObject> checkPoints;

    // Update is called once per frame
    void Update()
    {
      

     if(player.GetComponent<PlayerHealth>().checkHealth() <= 0) { //90 FOR TESTING PURPOSE CHANGE TO 0 
            player.transform.position = respawnPoint.transform.position;

            Physics.SyncTransforms();
            player.GetComponent<PlayerHealth>().respawn();
     }
         
    }

    private void OnTriggerEnter(Collider other)
    {
        // if(other.CompareTag("Player"))
        // {
        //     player.transform.position = respawnPoint.transform.position;
        //     Physics.SyncTransforms();
        // }

        if(other.CompareTag("Checkpoint"))
        {
            respawnPoint.transform.position = player.transform.position;
            //vectorPoint = player.transform.position;
            Destroy(other.gameObject);
            

        }
        
    }

}
