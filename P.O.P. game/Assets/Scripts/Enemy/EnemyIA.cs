using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    public Transform Target;
    public float FollowPlayerDistance;
    public Transform[] Waypoints;

    private NavMeshAgent agent;
    private Animator animator;
    private float distance;
    private float waypointDistance;
    private int currentWaypoint = 0;
    private bool isAttacking = false;

    private enum EnemyState { Patrolling, Chasing, Attacking, Resting }
    private EnemyState currentState = EnemyState.Patrolling;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.SetBool("move", true);
    }

    void Update()
    {
        distance = Vector3.Distance(agent.transform.position, Target.position);

        switch (currentState)
        {
            case EnemyState.Patrolling:
                Patrol();
                if (distance < FollowPlayerDistance)
                {
                    currentState = EnemyState.Chasing;
                }
                break;

            case EnemyState.Chasing:
                ChasePlayer();
                if (distance < 2.8f)
                {
                    currentState = EnemyState.Attacking;
                    StartCoroutine(Attack());
                }
                else if (distance >= FollowPlayerDistance)
                {
                    currentState = EnemyState.Patrolling;
                }
                break;

            case EnemyState.Attacking:
                // Se maneja en la corrutina
                break;

            case EnemyState.Resting:
                // No hacer nada mientras descansa
                break;
        }
    }

    void Patrol()
    {
        if (currentWaypoint >= Waypoints.Length) currentWaypoint = 0;

        agent.isStopped = false;
        agent.SetDestination(Waypoints[currentWaypoint].position);
        waypointDistance = Vector3.Distance(transform.position, Waypoints[currentWaypoint].position);

        if (waypointDistance < 3f)
        {
            StartCoroutine(Rest());
        }
    }

    void ChasePlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(Target.position);
        animator.SetBool("move", true);
    }

    IEnumerator Attack()
    {
        currentState = EnemyState.Attacking;
        agent.isStopped = true;
        animator.SetBool("move", false);
        animator.SetBool("Attack", true);

        yield return new WaitForSeconds(1f);

        animator.SetBool("Attack", false);
        currentState = EnemyState.Chasing;
    }

    IEnumerator Rest()
    {
        currentState = EnemyState.Resting;
        animator.SetBool("move", false);
        agent.isStopped = true;

        yield return new WaitForSeconds(3f);

        currentWaypoint++;
        currentState = EnemyState.Patrolling;
        animator.SetBool("move", true);
        agent.isStopped = false;
    }
}
