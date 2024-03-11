using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NarrativeTrigger : MonoBehaviour
{

    public GameObject narrativeObj;
    private bool isInteracting;
    public bool hasInteracted;

    private int counter;

    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text interactText;
    // Start is called before the first frame update
    void Start()
    {
        //starts with no dialogue text (hidden)
        dialogueText.enabled = false;
        interactText.enabled = false;
        counter =0; //resetting counter
    }

    // // Update is called once per frame
    void Update()
    {
       
        if( isInteracting && Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("discovered new narrative...");

            //update the text field here 

            //display the dialogue text
            interactText.enabled =false;
            dialogueText.enabled = true;
            counter +=1;
            if(counter <=1){
                hasInteracted = true;
            }
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
            //has interacted once so add 1 to counter 
            
            interactText.enabled = true;
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
            interactText.enabled =false;
            dialogueText.enabled = false;
            
        }
    }
    
}
