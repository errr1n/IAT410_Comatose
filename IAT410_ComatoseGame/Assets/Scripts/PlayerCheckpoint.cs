using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//PLAYER CHECKPOINTS THIS IS THE ACTUAL CODE DONT BE SILLY 
public class PlayerCheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private  List<GameObject> checkPoints;
    [SerializeField] private Vector3 spawnPoint;

    [SerializeField] private TMP_Text checkpointText;

    private int duration = 3;
    private int timeRemaining;
    private bool isCountingDown = false;
  
    //test to define first respawn point
    void Start() 
    {
        spawnPoint = new Vector3(122.1f, 6.24f, 87.56f);
        checkpointText.enabled = false;
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
            checkpointText.enabled = true;
            if(!isCountingDown)
            {
                timeRemaining = duration;
                Invoke("Tick",1f);
            }
            spawnPoint = other.transform.position;
            Destroy(other.gameObject);
            //Destroy(checkPoint);
        }
    }

    private void Tick() 
    {
        timeRemaining--;
        if(timeRemaining >0) {
            Invoke("Tick", 1f);
        } else {
            isCountingDown = false;
            checkpointText.enabled = false;
        }
    }
   
}


