using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    private Vector3 targetPlayer, shootDirection;
    private GameObject player;
    private float speed = 2f;
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
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            //other.GetComponent<player>().Damage();
            Debug.Log("hit player");
            Destroy(this.gameObject);
        }
    }
}
