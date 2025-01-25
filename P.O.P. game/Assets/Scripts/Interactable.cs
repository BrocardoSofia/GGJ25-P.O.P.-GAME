using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string promptMenssage; // message displayed to player when looking at an interactable 
    
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        // template function to be overridden by our subclases
    }
}
