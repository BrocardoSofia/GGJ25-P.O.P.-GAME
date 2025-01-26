using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true;
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToCredits()
    {
        string scene = "Credits";

        SceneManager.LoadScene(scene);
    }
}
