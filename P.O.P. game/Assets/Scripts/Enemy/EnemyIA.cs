using UnityEngine;
using UnityEngine.AI; 

public class EnemyIA : MonoBehaviour
{
    public Transform Target;
    public float AttackDistance;
    
    private NavMeshAgent agent;
    private float distance;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
         distance = Vector3.Distance(agent.transform.position, Target.position);

         if (distance < AttackDistance)
         {
             agent.isStopped = true;
         }
         else
         {
             agent.isStopped = false;
             agent.SetDestination(Target.position);
             agent.speed = (transform.position - Target.position).magnitude;
         }
    }
}
