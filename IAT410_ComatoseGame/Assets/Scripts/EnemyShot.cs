using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    private Vector3 targetPlayer, shootDirection;
    private GameObject player;
    private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        player  = GameObject.Find("Player");

        if(player != null){
            targetPlayer = player.transform.position;
        } else 
        {
            Debug.Log("EnemyShot.player is NULL");
        }
        shootDirection = (targetPlayer - transform.position).normalized * speed;
        
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(shootDirection * Time.deltaTime);
        //transform.position += transform.forward *speed* Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.collider.tag == "Player"){
            //other.GetComponent<player>().Damage();
            Debug.Log("hit player");
            Destroy(this.gameObject);
        }
    }
}
