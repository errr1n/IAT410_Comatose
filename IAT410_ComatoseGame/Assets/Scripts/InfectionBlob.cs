using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfectionBlob : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private int health;
    public GameObject boss;
    [SerializeField] private TMP_Text immuneText; 

    private float timeLeft = 3.0f;
    private bool startTime;
    void Awake()
    {
        health =3;
        immuneText.enabled = false;
        startTime = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(health <=0)
        {
            //destroy infection blob
            Destroy(gameObject);
        }

        if(startTime)
        {
            //time has started after player tried to hit the infection 
            timeLeft -= Time.deltaTime;
            if(timeLeft <= 0 )
            {
                immuneText.enabled = false;
            }
        }
       
    }

    private void OnTriggerEnter(Collider collision){
        if(collision.gameObject.tag == "PlayerAttack"){

            //check if boss is dead 

            //if boss is dead - player able to destroy the infection 
            if(boss == null) 
            {
                health-=1;
                Debug.Log("hit infection");
            }
            else {
                Debug.Log("did not kill boss yet");
                immuneText.enabled = true;
                startTime = true;
                
            }
            
            
        }
    }



}
