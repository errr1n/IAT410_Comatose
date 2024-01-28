// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// public class AIController : MonoBehaviour
// {
//     public NavMeshAgent navMeshAgent;
//     public float startWaitTime = 4;
//     public float timeToRotate = 2;
//     public float speedWalk = 6;
//     public float speedRun = 9;
//     public float viewRadius = 15;
//     public float viewAngle = 90;
//     public LayerMask playerMask;
//     public LayerMask obstacleMask;
//     public float meshResolution = 1f;
//     public int edgeIterations = 4;
//     public float edgeDistance = 0.5;
//     public Transform[] waypoints;
//     int m_CurrentWaypointIndex;
//     Vector3 playerLastPosition = Vector3.zero;
//     Vector3 m_PlayerPosition;
    
//     float m_waitTime;
//     float m_TimeToRotate;
//     bool m_PlayerInRange;
//     bool m_PlayerNear;
//     bool m_isPatrol;
//     bool m_caughtPlayer;



//     // Start is called before the first frame update
//     void Start()
//     {
//         //initialize variables
//         m_PlayerPosition = Vector3.zero;
//         m_isPatrol = true;
//         m_caughtPlayer = false;
//         m_PlayerInRange = false;
//         m_waitTime = startWaitTime;
//         m_TimeToRotate = timeToRotate;

//         m_CurrentWaypointIndex =0;
//         navMeshAgent = GetComponent<navMeshAgent>();
        
//         navMeshAgent.isStopped = false;
//         navMeshAgent.speed = false;
//         navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         EnvironmentView();

//         if(!m_isPatrol)
//         {
//             Chasing();
//         } else 
//         {
//             Patrolling();
//         }
//     }

//     private void Patrolling()
//     {
//         if(m_PlayerNear)
//         {
//             if(m_TimeToRotate <=0)
//             {
//                 Move(speedWalk);
//                 SpotPlayer(playerLastPosition);
//             }
//             else{
//                 Stop();
//                 m_TimeToRotate -= Time.deltaTime;
//             }
//         }
//          else 
//         {
//             m_PlayerNear = false;
//             playerLastPosition = Vector3.zero;
//             navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);

//             if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
//             {
//                 if(m_waitTime <=0)
//                 {
//                     NextPoint();
//                     Move(speedWalk);
//                     m_waitTime = startWaitTime;
//                 } else 
//                 {
//                     Stop();
//                      m_TimeToRotate -= Time.deltaTime;
//                 }
//             }
//         }
//     }

//     private void Chasing()
//     {
//         m_PlayerNear = false;
//         playerLastPosition = Vector3.zero;

//         if(!m_caughtPlayer)
//         {
//             Move(speedRun);
//             navMeshAgent.SetDestination(m_PlayerPosition);
//         }
//         if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
//         {
//             if(m_waitTime <= 0 && !m_caughtPlayer && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player")) >= 6f )
//             {
//                 m_isPatrol = true;
//                 m_PlayerNear = false;
//                 Move(speedWalk);
//                 m_TimeToRotate = timeToRotate;
//                 m_waitTime = startWaitTime;
//                 navMeshAgent.SetDestination(waypoints[m_caughtPlayer].position);
//             }
//             else 
//             {
//                 if(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player") ) >= 2f)
//                 {
//                     Stop();
//                     m_TimeToRotate -= Time.deltaTime;
//                 }
//             }
//         }
//     }


//     void CaughtPlayer()
//     {
//         m_caughtPlayer = true;
//     }

//     void Move(float speed)
//     {
//         navMeshAgent.isStopped = false;
//         navMeshAgent.speed = speed;
//     }

//     void Stop()
//     {
//         navMeshAgent.isStopped = true;
//         navMeshAgent.speed = 0;
//     }

//     public void NextPoint()
//     {
//         m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
//         navMeshAgent.SetDestination(waypoints[m_caughtPlayer].position);
//     }

//     void SpotPlayer(Vector3 player)
//     {
//         navMeshAgent.SetDestination(player);

//         if(Vector3.Distance(transform.oisition, player) <=0.3)
//         {
//             if(m_waitTime <=0)
//             {
//                 m_PlayerNear = false;
//                 Move(speedWalk);
//                 navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
//                 m_waitTime = startWaitTime;
//                 m_TimeToRotate = timeToRotate;
//             }else 
//             {
//                 Stop();
//                 m_waitTime -= timeToRotate.deltaTime;
//             }
//         }

//     }

//     void EnvironmentView()
//     {
//         Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRadius, playerMask);

//         for(int i=0; i< playerInRange.Length; i++)
//         {
//             Transform player = playerInRange[i].transform;
//             Vector3 dirToPlayer = (player.position - transform.position).normalized;

//             if(Vector3.Angle(transform.forward, dirToPlayer) <viewAngle / 2)
//             {
//                 float dstToPlayer = Vector3.Distance(transform.position, player.position);

//                 if(!Physics.Raycast(trasnform.position, dirToPlayer, dstToPlayer, obstacleMask)){
//                     m_PlayerInRange = true;
//                     m_isPatrol = false;
//                 }
//                 } else 
//                 {
//                     m_PlayerInRange = false;
//                 }

//             if(Vector3.Distance(transform.position, player.position) > viewRadius)
//             {
//                 m_PlayerInRange = false;
//             }
//         }
//         if(m_PlayerInRange)
//         {
//             m_PlayerPosition = player.transform.position;
//         }
//     }
// }
