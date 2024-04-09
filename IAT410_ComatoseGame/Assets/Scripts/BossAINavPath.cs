using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAINavPath : MonoBehaviour
{
    

    public UnityEngine.AI.NavMeshAgent agent;
    public Transform player, spawnPoint;
    public LayerMask isGround, isPlayer;


  
    public GameObject projectile, projectile2, projectile3;
    //patrolling 
    public Vector3 walkPoint, newpos;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    [SerializeField] float timeBetweenAttacks;
  
    bool alreadyAttacked;

    //states
    public float sightRange, attackRange, health;
    public bool playerInSightRange,playerInAttackRange;



    private void Awake()
    {
        player = GameObject.Find("PlayerArmature").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
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
        //agent.SetDestination(transform.position);
        transform.LookAt(player);



        

        if(!alreadyAttacked)
        {
             
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward *32f, ForceMode.Impulse);
            rb.AddForce(transform.up *5f, ForceMode.Impulse);
            


            //creating second bullet at different rotation 
            GameObject bullet2 = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            Rigidbody rb2 = bullet2.GetComponent<Rigidbody>();
            rb2.AddForce(transform.forward *32f, ForceMode.Impulse);
            rb2.AddForce(transform.right *3, ForceMode.Impulse);
            rb2.AddForce(transform.up *5f, ForceMode.Impulse);

          

            //create third bullet at different rotation here
            GameObject bullet3 = Instantiate(projectile,transform.position, transform.rotation) as GameObject;
            Rigidbody rb3 = bullet3.GetComponent<Rigidbody>();
            rb3.AddForce(transform.forward *35f, ForceMode.Impulse);
            rb3.AddForce(transform.up *5f, ForceMode.Impulse);
            rb3.AddForce(-transform.right *3f, ForceMode.Impulse);


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
        
        
        //if health reaches half - increase the boss attack speed
        

        if(health<=0 ) Invoke(nameof(DestroyEnemy), 3f);
   }

   public void IncreaseFireSpeed()
   {
        timeBetweenAttacks = 0.5f;
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

}
