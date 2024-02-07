using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    public GameObject player;
    Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        //setting spawn point tobe original position of player
        spawnPoint = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerHealth>().checkHealth() <= 90){
       
            player.transform.position = spawnPoint;
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Checkpoint");
            
            spawnPoint = other.transform.position;
            //Destroy(checkPoint);
        }
    }
}


