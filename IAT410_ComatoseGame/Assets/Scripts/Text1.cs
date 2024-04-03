using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// uses unity UI
using UnityEngine.UI;

public class Text1 : MonoBehaviour
{

    // create a UI object 
    public GameObject UIObject;
    // create a trigger game object
    public GameObject trigger;

    // adjustable float to change delay of disapearance
    [SerializeField] float delay = 1f;

    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] float timeBtwChars;
     [SerializeField] float timeBtwWords;
    public string[] stringArray;
    int i =0;
    private bool beginPlay;

    // by default, the text is not visible
    void Start()
    {
        // sets visibilty of UI text object to false
        UIObject.SetActive(false);
        beginPlay = false;
      
    }

    // upon entering the trigger
    void OnTriggerEnter(Collider other)
    {
        // searches for player tag
        if(other.tag == "Player")
        {
            //checks if player has already activated trigger (will only play animation once)
            if(beginPlay == false)
            {
                beginPlay = true;
                // sets visibilty of UI text object to true
                UIObject.SetActive(true);

                // starts coroutine (timer)
                // StartCoroutine(Delay(delay));
                EndCheck();
            }
        }
    }

  

    // // coroutine (timer) funtion which takes in temporary variable
    // IEnumerator Delay(float _delay)
    // {
    //     // coroutine yield and waits for specified number of seconds
    //     yield return new WaitForSecondsRealtime(_delay);
    //     // sets visibilty of UI text object to false
    //     UIObject.SetActive(false);
    //     // destroys trigger (can only play once)
    //     Destroy(trigger);
    // }

    void EndCheck()
    {
        if(i<= stringArray.Length - 1)
        {
            textMeshPro.text = stringArray[i];
            StartCoroutine(TextVisible());
        }
    }

    private IEnumerator TextVisible()
    {
        textMeshPro.ForceMeshUpdate();
        int totalVisibleCharacters = textMeshPro.textInfo.characterCount;
        int counter =0;

        while (true)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            textMeshPro.maxVisibleCharacters = visibleCount;

            if(visibleCount >= totalVisibleCharacters)
            {
                i +=1;
                Invoke("EndCheck", timeBtwWords);
                break;
            }

            counter += 1;
            yield return new WaitForSeconds(timeBtwChars);
        }
        // Destroy(trigger);

    }
}

// for future reference of erins stupidity

// // Update is called once per frame
//     void Update()
//     {
//         // if(timerStarted == true)
//         // {
//             // Debug.Log(timerStarted);
//             // StartCoroutine(Delay());
//             // timerStarted = false;
//             // Debug.Log(timerStarted);
//         // }

//         // Debug.Log(timerStarted);
//     }

    // void awake()
    // {
    //     // StartCoroutine(Delay());
    //     Debug.Log("Awake");
    // }

    // upon exiting the trigger
    // void OnTriggerExit(Collider other)
    // {
    //     // sets visibilty of UI text object to false 

    //     //(HERE)
    //     // UIObject.SetActive(false);
    //     // removeText();
    //     // Invoke("removeText", 3);

    //     // destorys the trigger so text only appears once
    //     Destroy(trigger);
    // }

    // ERIN's edits
    // void removeText()
    // {
        // sets visibilty of UI text object to false 
        // UIObject.SetActive(false);
    // }

