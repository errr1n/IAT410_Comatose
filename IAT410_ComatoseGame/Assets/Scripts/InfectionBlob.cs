using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionBlob : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private int health;
    public GameObject boss;

    void Awake()
    {
        health =3;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <=0)
        {
            //destroy infection blob
            Destroy(gameObject);
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
            }
            
            
        }
    }
}
