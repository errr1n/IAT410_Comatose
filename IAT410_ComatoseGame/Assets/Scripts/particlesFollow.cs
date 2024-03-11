using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesFollow : MonoBehaviour
{
    //public GameObject particleEffect;
    public GameObject p1, p2, p3, p4;
    private GameObject target;
    //public Rigidbody2D rb2;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Test");
       // Instantiate(particleEffect, target.transform);
       Instantiate(p1, target.transform);
       Instantiate(p2, target.transform);
       Instantiate(p3, target.transform);
       Instantiate(p4, target.transform);
    }

    // Update is called once per frame
    void Update()
    {
       // Instantiate(particleEffect, player.transform);
        //particleEffect.transform.SetParent(target.transform);
        // p1.transform.parent = target.transform;
        // p2.transform.parent = target.transform;
        // p3.transform.parent = target.transform;
        // p4.transform.parent = target.transform;
        // particleEffect.transform.localScale = new Vector3(0.09f,0.09f,0.09f);
        // particleEffect.transform.localPosition = new Vector3(0f,0f,0f);
        
        
       
    }
}
