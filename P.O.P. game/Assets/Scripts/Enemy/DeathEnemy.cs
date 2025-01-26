using System;
using UnityEngine;
using UnityEngine.AI;

public class DeathEnemy : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float upForce;
    private NavMeshAgent agent;
    private EnemyIA ia;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        ia = GetComponent<EnemyIA>();
    }

    public void Death()
    {
        Debug.Log("Death");
        agent.enabled = false;
        ia.enabled = false;
        Vector3 force = Vector3.up * upForce;
        rb.AddForce(force, ForceMode.Impulse);
        Invoke("destroyEnemy", 2f);
    }

    private void destroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
