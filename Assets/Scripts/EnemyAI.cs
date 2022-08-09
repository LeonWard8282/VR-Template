using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public LayerMask whatisGround, whatisPlayer;


    //patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkpointRange;

    // attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Child Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatisPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatisPlayer);

        if(!playerInSightRange && !playerInAttackRange) 
        {
            Patroling();
        }
        if(playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if(playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
    }


    private void Patroling()
    {
        if(!walkPointSet)
        {
            SearchWalkPoints();
        }
        if(walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }
            //agent.SetDestination(walkPoint);
        

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if(distanceToWalkPoint.magnitude < .5f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoints()
    {
        float randomZ = Random.Range(-walkpointRange, walkpointRange);
        float randomX = Random.Range(-walkpointRange, walkpointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatisGround))
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
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if(!alreadyAttacked)
        {
            // Attack Code here

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
