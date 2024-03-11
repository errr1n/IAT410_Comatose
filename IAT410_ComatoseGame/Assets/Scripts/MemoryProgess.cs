using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryProgess : MonoBehaviour
{

    public float maxProgress;
    public float curProgress;

    public Slider progressSlider;
    
    public GameObject bear, shelf, bed;
    private bool test;

    private bool bearInteracted, shelfInteracted, bedInteracted;
    void Awake()
    {
        //counter =0;
        curProgress = 0;
        progressSlider.maxValue = maxProgress;
        progressSlider.value = curProgress;

        bearInteracted = false;
        shelfInteracted = false;
        bedInteracted = false;
    }
   
    

    // Update is called once per frame
    void Update()
    {
        //need to check for each item
        
        //check if bear interacted with 
        //test =bear.GetComponent<NarrativeTrigger>().hasInteracted;
        if(bear.GetComponent<NarrativeTrigger>().hasInteracted && bearInteracted == false) {
            
            addProgress();
            bearInteracted = true;

        } 
       if(shelf.GetComponent<NarrativeTrigger>().hasInteracted && shelfInteracted == false) {
            
            addProgress();
            shelfInteracted = true;

        } 
        if(bed.GetComponent<NarrativeTrigger>().hasInteracted && bedInteracted == false) {
            
            addProgress();
            bedInteracted = true;

        } 
        
       

    }


    public void addProgress() 
    {
        //adds 20% to bar
        curProgress += 20;
        progressSlider.value = curProgress;
        Debug.Log(curProgress);
    }
}
