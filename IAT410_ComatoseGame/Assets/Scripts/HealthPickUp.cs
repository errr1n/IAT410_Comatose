using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public AudioSource healthSFX;
    // Start is called before the first frame update
    void Awake()
    {
        healthSFX = GetComponents<AudioSource>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        //chceks if the player collided with the health pickup 
        if(collision.gameObject.tag == "Player") {
            Debug.Log("player hit health");

            //call player health script 
            
            collision.GetComponent<PlayerHealth>().addHealth(Random.Range(10,30));
            healthSFX.Play();
            Destroy(gameObject);

        }
    }
}
