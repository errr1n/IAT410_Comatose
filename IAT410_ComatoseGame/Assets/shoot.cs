using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    public Rigidbody bullet;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Fire1")){
            var clone = Instantiate(bullet, transform.position, transform.rotation);
            clone.velocity = Vector3.forward * speed;
        }
        
    }
}
