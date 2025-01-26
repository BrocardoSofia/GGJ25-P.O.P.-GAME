using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLogic : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    public void GameOver()
    {
        string scene = "GameOver";

        SceneManager.LoadScene(scene);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
