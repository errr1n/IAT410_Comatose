using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossOne : MonoBehaviour
{

    //START OF ERINS COMMENTS

//     public NavMeshAgent agent;
//     public Transform player, spawnPoint;
//     public LayerMask isGround, isPlayer;

  
//     public GameObject projectile;

//     //patrolling 
//     public Vector3 walkPoint;
//     bool walkPointSet;
//     public float walkPointRange;

//     //attacking
//     public float timeBetweenAttacks;
  
//     bool alreadyAttacked;

//     //states
//     public float sightRange, attackRange, health;
//     public bool playerInSightRange,playerInAttackRange;

//     //projectile boss attacks
//     [SerializeField] private int numberOfProjectiles;
//     [SerializeField] private float radius=5f;
//      [SerializeField] private float moveSpeed=5f;
//     Vector3 startPoint;


//     private void Awake()
//     {
//         player = GameObject.Find("PlayerArmature").transform;
//         agent = GetComponent<NavMeshAgent>();
//     }

//     private void Patrolling()
//     {
//         if(!walkPointSet) SearchWalkPoint();

//         if(walkPointSet) agent.SetDestination(walkPoint);
        
//         Vector3 distanceToWalkPoint = transform.position - walkPoint;

//         //walkpoint reached
//         if(distanceToWalkPoint.magnitude <1f)
//             walkPointSet = false;
            
//     }

//     private void SearchWalkPoint()
//     {
//         //random point in range
//         float randomZ = Random.Range(-walkPointRange, walkPointRange);
//         float randomX = Random.Range(-walkPointRange, walkPointRange);

//         walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

//         if(Physics.Raycast(walkPoint, -transform.up, 2f, isGround))
//         {
//             walkPointSet = true;
//         }
//     }

//     private void ChasePlayer() 
//     {
//         agent.SetDestination(player.position);
//     }

//     private void AttackPlayer()
//     {
//         //stop enemy from moving 
//         agent.SetDestination(transform.position);
//         transform.LookAt(player);

//         if(!alreadyAttacked)
//         {
//             //original projectile
//             Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
//             rb.AddForce(transform.forward *32f, ForceMode.Impulse);
//             rb.AddForce(transform.up *5f, ForceMode.Impulse);
            
//             //spread stuff
//            Rigidbody rb2 = Instantiate(projectile, transform.position.x+100, Quaternion.identity).GetComponent<Rigidbody>();
//             rb2.AddForce(transform.forward *32f, ForceMode.Impulse);
//             rb2.AddForce(transform.up *5f, ForceMode.Impulse);
            
//             alreadyAttacked = true;
//             Invoke(nameof(ResetAttack), timeBetweenAttacks);
//         } 
   
//     }
   


//     private void ResetAttack() 
//     {
//         alreadyAttacked = false;
//     }
   
//    public void TakeDamage(int damage)
//    {
//         health -= damage;

//         if(health<=0 ) Invoke(nameof(DestroyEnemy), 3f);
//    }

//    public void DestroyEnemy(){
//         Destroy(gameObject);
//    }
//     // Update is called once per frame
//     void Update()
//     {
//         //checking for sight and attack range
//         playerInSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
//         playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

//         //enemy patrols if not in attack or sight range of player
//         if(!playerInSightRange && !playerInAttackRange) Patrolling();
//         if(playerInSightRange && !playerInAttackRange) ChasePlayer();
//         if(playerInSightRange && playerInAttackRange) AttackPlayer();
//     }



    //END OF ERINS COMMENTS

    
    // public void OnCollisionEnter(Collision collision){

    //     if(collision.collider.tag == "projectile"){
    //         //collide with player projectile
    //         health -=1;
    //         Destroy(collision.gameObject);
    //         Invoke(nameof(DestroyEnemy),0.5f);
            
    //     }
        
    // }
   
}


