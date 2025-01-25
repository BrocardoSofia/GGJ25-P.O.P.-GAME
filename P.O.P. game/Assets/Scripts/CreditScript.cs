using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScript : MonoBehaviour
{
    public void OnCreditAnimationEnd()
    {
        SceneManager.LoadScene(0);
    }
}
