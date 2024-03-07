using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleFollow : MonoBehaviour
{

    private Transform target;
    public Rigidbody2D rb2;
    public float speed;
    public ParticleSystem ps1;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        ps1 = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
        //rb2.velocity = Vector2.zero;
        playParticles();
    }

    void playParticles(){
        ps1.Play();
    }
}
