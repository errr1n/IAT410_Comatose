using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivalEnemyShot : MonoBehaviour
{

    //public void newMoveSpeed;
    private float timeLeft = 1.8f;

    public GameObject player;
    private bool startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = false;
        player = GameObject.Find("PlayerArmature");
    }

    // Update is called once per frame
    void Update()
    {
        // if(startTime)
        // {
        //     timeLeft -= Time.deltaTime;
        //     if(timeLeft <= 0 )
        //     {
        //         player.GetComponent<StarterAssets.ThirdPersonController>().setMoveSpeed(10);
        //     }
        // }
        
        Invoke(nameof(DestroyShot), 2f);


        
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.collider.tag == "Player"){
            //other.GetComponent<player>().Damage();
            Debug.Log("hit player");
            
            //calls to the player health script and sends damage amount to update their healthbard
            // adjust as needed
            //collision.collider.GetComponent<PlayerHealth>().sendDamage(100);
            // Destroy(this.gameObject);

            //TEST
            // collision.collider.GetComponent<StarterAssets.ThirdPersonController>().setMoveSpeed(5);
            // startTime = true;
            
            Destroy(this.gameObject);
        }
       

        
    }

    public void DestroyShot(){
        Destroy(gameObject);
   }
}
