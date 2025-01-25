using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyIA : MonoBehaviour
{
    // Aca va el transform del player que es lo que vamos a perseguir
    public Transform Target;
    // La distancia minima que debe haber entre el enemigo y player para que lo persiga
    public float FollowPlayerDistance;
    // Los waypoint son los puntos que va a seguir el enemigo cuando no esta persiguiendo al jugador
    public Transform[] Waypoints;
    
    // Variables privadas para hacer la comprobaciones
    private NavMeshAgent agent;
    private float distance;
    private float waypointDistance;
    private bool followPlayer;
    private int i = 0;
    
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
         // Obtenemos la distacia que hay entre el player y el enemigo en cada frame
         distance = Vector3.Distance(agent.transform.position, Target.position);
        
         // Se verifica la distancia para perseguir al player
         if (distance < FollowPlayerDistance)
         {
             followPlayer = true;
         }
         else
         {
             followPlayer = false;
         }

         if (followPlayer)
         {
             // Le decimos que se puede mover
             agent.isStopped = false;
             // Le pasamos la posicion del player para que vaya ahi
             agent.SetDestination(Target.position);
             // Le decimos a que velocidad tiene que ir
             // Lo pongo asi para que no sea tan brusco el movimiento y sea mas suave
             agent.speed = (transform.position - Target.position).magnitude;
         }
         else
         {
             // Le decimos a que waypoint de la lista tiene que ir
             agent.SetDestination(Waypoints[i].position);
             
             // Le damos una velocidad para que se mueva
             agent.speed = (transform.position - Waypoints[i].position).magnitude;
             
             // Obtenemos la distancia que hay entre el waypoint que estamos siguiendo y la posicion del enemigo
             waypointDistance = Vector3.Distance(transform.position, Waypoints[i].position);
             
             // Si la distancia es menor a 1 empezamos a perseguir el siguiente waypoint
             if (waypointDistance < 1) i++;

             // Reiniciamos la persecusion cuando llegamos al ultimo waypoint de la lista
             if (i == Waypoints.Length) i = 0;
         }
    }
}
