using UnityEngine;

public class Alfajor : Interactable
{
   
    [SerializeField]
    private PlayerHealth health; // Referencia al jugador para restaurar salud
    public float healAmount;

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    protected override void Interact()
    {
        health.restoreHealth(healAmount);
        Destroy(gameObject);

    }

  
}
