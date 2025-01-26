using System;
using UnityEngine;

public class DetectedEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DeathEnemy deathEnemy = other.gameObject.GetComponent<DeathEnemy>();
            if (deathEnemy != null)
            {
                deathEnemy.Death();
                Destroy(this.gameObject);
            }
            else
            {
                Debug.LogWarning("El objeto colisionado no tiene el componente DeathEnemy.");
            }
        }
    }
}