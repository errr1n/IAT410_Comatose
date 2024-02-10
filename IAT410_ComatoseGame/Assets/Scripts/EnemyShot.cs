using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Invoke(nameof(DestroyShot), 2f);
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.collider.tag == "Player"){
            //other.GetComponent<player>().Damage();
            Debug.Log("hit player");
            
            //calls to the player health script and sends damage amount to update their healthbard
            // adjust as needed
            //collision.collider.GetComponent<PlayerHealth>().sendDamage(10);
            Destroy(this.gameObject);
        }
    }

    public void DestroyShot(){
        Destroy(gameObject);
   }
}
