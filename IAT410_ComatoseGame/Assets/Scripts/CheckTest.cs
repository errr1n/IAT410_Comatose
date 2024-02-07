using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTest : MonoBehaviour
{
    public GameObject checkPoint;
    Vector3 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        //setting spawn point tobe original position of player
        //spawnPoint = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<PlayerHealth>().checkHealth() <= 100){
            gameObject.transform.position = spawnPoint;
            gameObject.GetComponent<PlayerHealth>().respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            spawnPoint = checkPoint.transform.position;
            //Destroy(checkPoint);
        }
    }
}
