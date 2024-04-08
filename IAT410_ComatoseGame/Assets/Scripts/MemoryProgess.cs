using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemoryProgess : MonoBehaviour
{

    public float maxProgress;
    public float curProgress;

    public Slider progressSlider;
    
    public GameObject bear, shelf, bed, boss, infection, carousel, ferris, carnivalBoss, infection2;
    private bool test;

    private bool bearInteracted, shelfInteracted, bedInteracted, bossInteracted, infectionDead, carouselInteracted, ferrisInteracted, carnivalBossInteracted, infection2Dead;

    
    [SerializeField] private TMP_Text progressText;
    void Awake()
    {
        //counter =0;
        curProgress = 0;
        progressSlider.maxValue = maxProgress;
        progressSlider.value = curProgress;

        bearInteracted = false;
        shelfInteracted = false;
        bedInteracted = false;
        bossInteracted = false;
        infectionDead = false;

        progressText.text = "0%";
    }
   
    

    // Update is called once per frame
    void Update()
    {
        //need to check for each item
    
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
        
       if(boss == null && bossInteracted == false)  
       {
            addProgress();
            bossInteracted = true;
       }
       if(infection == null && infectionDead == false) 
       {
            addProgress();
            infectionDead = true;
       }

       if(carousel.GetComponent<NarrativeTrigger>().hasInteracted && carouselInteracted == false) 
       {
            addProgress();
            carouselInteracted = true;
       }

       if(ferris.GetComponent<NarrativeTrigger>().hasInteracted && ferrisInteracted == false) {
            
            addProgress();
            ferrisInteracted = true;

        } 

        if(carnivalBoss == null && carnivalBossInteracted == false)  
       {
            addProgress();
            carnivalBossInteracted = true;
       }
       if(infection2 == null && infection2Dead == false) 
       {
            addProgress();
            infection2Dead = true;
       }

    }


    public void addProgress() 
    {
        //adds 20% to bar
        curProgress += 20;
        progressSlider.value = curProgress;
        Debug.Log(curProgress);

        //update text at some point to reflect percent
        progressText.text = curProgress + "%";
    }
}
