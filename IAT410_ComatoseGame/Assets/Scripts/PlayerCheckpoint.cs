using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PLAYER CHECKPOINTS THIS IS THE ACTUAL CODE DONT BE SILLY 
public class PlayerCheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private  List<GameObject> checkPoints;
    [SerializeField] private Vector3 spawnPoint;
  

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerHealth>().checkHealth() <= 100){
       
            player.transform.position = spawnPoint;
            gameObject.GetComponent<PlayerHealth>().respawn();
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            Debug.Log("Checkpoint");
            
            spawnPoint = other.transform.position;
            Destroy(other.gameObject);
            //Destroy(checkPoint);
        }
    }
}


