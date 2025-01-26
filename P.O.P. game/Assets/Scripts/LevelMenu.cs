using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    public Canvas menu;
    private bool isPaused = false;

    void Start()
    {
        Cursor.visible = false;
        menu.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGameFunction();
            }
        }
    }

    void PauseGameFunction()
    {
        // Pausa el juego y muestra el Canvas de Pausa
        Time.timeScale = 0f;
        menu.gameObject.SetActive(true);
        isPaused = true;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        // Reanuda el juego y oculta el Canvas de Pausa
        Time.timeScale = 1f;
        menu.gameObject.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
    }
}
