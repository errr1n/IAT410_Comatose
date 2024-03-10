using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NarrativeTrigger : MonoBehaviour
{

    public GameObject narrativeObj;
    private bool isInteracting;

    [SerializeField] private TMP_Text dialogueText;
    // Start is called before the first frame update
    void Start()
    {
        //starts with no dialogue text (hidden)
        dialogueText.enabled = false;
    }

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

            //update the text field here 

            //display the dialogue text
            dialogueText.text = "narrative 1";
            dialogueText.enabled = true;
            
        }
    }

    //displays the narrative text on screen
    private void deliverNarrative()
    {
        Debug.Log("discovered new narrative...");
    }

//checks if player entered the naarrative prompt thing - CHANGE TO ON COLLISION ENTER LATER ?
    private void OnTriggerEnter(Collider other){
        
        if(other.CompareTag("Player"))
        {
            Debug.Log("narrative available");
            //narrativeObj = other.gameObject;
            isInteracting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isInteracting = false;
            dialogueText.enabled = false;
        }
    }
    
}
