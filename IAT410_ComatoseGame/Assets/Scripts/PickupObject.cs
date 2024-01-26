using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public GameObject availablePickup;
    public GameObject playerRightHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyUp(KeyCode.I)) //change this key later to E once player health bar not attached to E anymore
            {
                pickupObj();
            }
    }

    public void pickupObj(){
        availablePickup.transform.SetParent(playerRightHand.transform);
        availablePickup.transform.localScale = new Vector3(1f,1f,1f);
        availablePickup.transform.localPosition = new Vector3(0f,0f,0f);
    }

    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("Pickup")){
            availablePickup = other.gameObject;
            Debug.Log("Its pickable");

           
        }
    }
}
