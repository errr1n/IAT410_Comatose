using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NarrativeTrigger : MonoBehaviour
{

    public GameObject narrativeObj;
    private bool isInteracting;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyUp(KeyCode.I)) 
        // {
        //     deliverNarrative();
        // }
        if( isInteracting && Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("discovered new narrative...");
        }
    }

    //displays the narrative text on screen
    private void deliverNarrative()
    {
        Debug.Log("discovered new narrative...");
    }

//checks if player entered the naarrative prompt thing - CHANGE TO ON COLLISION ENTER LATER ?
    private void OnTriggerEnter(Collider other){
        
        if(other.CompareTag("NarrativeObj"))
        {
            Debug.Log("narrative available");
            //narrativeObj = other.gameObject;
            isInteracting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("NarrativeObj"))
        {
            isInteracting = false;
        }
    }
  
 
}
