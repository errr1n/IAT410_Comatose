using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AINavPath : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask isGround, isPlayer;

    public Transform spawnPoint;
    public float enemySpeed =20;
    public GameObject projectile;
    //patrolling 
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    public float timeBetweenAttacks;
    [SerializeField] private float timer =2;
    bool alreadyAttacked;

    //states
    public float sightRange, attackRange, health;
    public bool playerInSightRange,playerInAttackRange;



    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Patrolling()
    {
        if(!walkPointSet) SearchWalkPoint();

        if(walkPointSet) agent.SetDestination(walkPoint);
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if(distanceToWalkPoint.magnitude <1f)
            walkPointSet = false;
            
    }

    private void SearchWalkPoint()
    {
        //random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, isGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer() 
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //stop enemy from moving 
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if(!alreadyAttacked)
        {

            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward *32f, ForceMode.Impulse);
            rb.AddForce(transform.up *8f, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        } 
   
    }
   

    

    private void ResetAttack() 
    {
        alreadyAttacked = false;
    }
   
   public void TakeDamage(int damage)
   {
        health -= damage;

        if(health<=0 ) Invoke(nameof(DestroyEnemy), 3f);
   }

   public void DestroyEnemy(){
        Destroy(gameObject);
   }
    // Update is called once per frame
    void Update()
    {
        //checking for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, isPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

        //enemy patrols if not in attack or sight range of player
        if(!playerInSightRange && !playerInAttackRange) Patrolling();
        if(playerInSightRange && !playerInAttackRange) ChasePlayer();
        if(playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    
    // public void OnCollisionEnter(Collision collision){
    //     if(collision.collider.tag == "projectile"){
    //         //collide with player projectile
    //         health -=1;
    //         Destroy(collision.gameObject);
    //         Invoke(nameof(DestroyEnemy),0.5f);
            
    //     }
        
    // }
}
