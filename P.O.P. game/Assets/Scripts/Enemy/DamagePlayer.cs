using System;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField]
    private float damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<PlayerHealth>().takeDamage(damage);
        }
    }
}
