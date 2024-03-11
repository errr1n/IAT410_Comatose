using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryProgess : MonoBehaviour
{

    public float maxProgress;
    public float curProgress;

    public Slider progressSlider;
    
    public GameObject bear;
    private bool test;

    private int counter;
    void Awake()
    {
        counter =0;
        curProgress = 0;
        progressSlider.maxValue = maxProgress;
        progressSlider.value = curProgress;
    }
   
    

    // Update is called once per frame
    void Update()
    {
        //need to check for each item
        
        //check if bear interacted with 
        //test =bear.GetComponent<NarrativeTrigger>().hasInteracted;
        if(bear.GetComponent<NarrativeTrigger>().hasInteracted && counter == 0) {
            
            addProgress();
            counter +=1;

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
