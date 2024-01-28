using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// uses unity UI
using UnityEngine.UI;

public class Text : MonoBehaviour
{

    // create a UI object 
    public GameObject UIObject;
    // create a trigger game object
    public GameObject trigger;

    // by default, the text is not visible
    void Start()
    {
        // sets visibilty of UI text object to false
        UIObject.SetActive(false);
    }

    // upon entering the trigger
    void OnTriggerEnter(Collider other)
    {
        // searches for player tag
        if(other.tag == "Player")
        {
            // sets visibilty of UI text object to true
            UIObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // upon exiting the trigger
    void OnTriggerExit(Collider other)
    {
        // sets visibilty of UI text object to false 

        //(HERE)
        // UIObject.SetActive(false);

        // destorys the trigger so text only appears once
        Destroy(trigger);
    }
}
