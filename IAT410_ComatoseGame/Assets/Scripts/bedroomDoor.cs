using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedroomDoor : MonoBehaviour
{
      public Transform door1, door2;
      public GameObject boss;
    // Start is called before the first frame update
    private int count;
    void Start()
    {
        count =0;
    }

    // Update is called once per frame
    void Update()
    {
         //open doors to next area here
         if(boss == null && count ==0)
         {
            //boss dead
           // door1.position = new Vector3(-33, 250, -61);
           door1.position += new Vector3(-4,0,0);
           door2.position += new Vector3(4,0,0);
           count +=1;
         }
        
                //door2.position = new Vector3(4, 250.5899, -61.7);
    }
}
