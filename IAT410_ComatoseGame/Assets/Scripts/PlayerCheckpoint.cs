using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PLAYER CHECKPOINTS THIS IS THE ACTUAL CODE DONT BE SILLY 
public class PlayerCheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private  List<GameObject> checkPoints;
    [SerializeField] private Vector3 spawnPoint;
  
    //test to define first respawn point
    void Start() 
    {
        spawnPoint = new Vector3(122.1f, 6.24f, 87.56f);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerHealth>().checkHealth() <= 0){
       
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


