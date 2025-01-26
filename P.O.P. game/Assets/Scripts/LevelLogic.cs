using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLogic : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    static public void GameOver()
    {
        string scene = "GameOver";

        SceneManager.LoadScene(scene);
    }

     static public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
