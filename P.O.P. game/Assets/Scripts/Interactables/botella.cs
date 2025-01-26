using UnityEngine;
using UnityEngine.Serialization;

public class botella : Interactable
{
     public int bulletAmount;

    void Start()
    {
       
    }

    void Update()
    {
        
    }

    protected override void Interact()
    {
        GetComponent<ShootController>().bulletCount += bulletAmount;
        Destroy(gameObject);

    }

  
}
