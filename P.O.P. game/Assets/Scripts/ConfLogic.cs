using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfLogic : MonoBehaviour
{
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
