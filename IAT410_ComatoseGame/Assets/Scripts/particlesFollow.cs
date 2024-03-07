using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesFollow : MonoBehaviour
{
    public GameObject particleEffect;
    private GameObject target;
    //public Rigidbody2D rb2;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Instantiate(particleEffect, target.transform);
    }

    // Update is called once per frame
    void Update()
    {
       // Instantiate(particleEffect, player.transform);
      // particleEffect.transform.SetParent(target.transform);
       //particleEffect.transform.localScale = new Vector3(0.09f,0.09f,0.09f);
        //particleEffect.transform.localPosition = new Vector3(0f,0f,0f);
       
        
       
    }
}
