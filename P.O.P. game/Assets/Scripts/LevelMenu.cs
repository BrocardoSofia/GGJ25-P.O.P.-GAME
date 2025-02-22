using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Canvas menu;
    private bool isPaused = false;
    [SerializeField] 
    private AudioMixer audioMixer;

    public Slider musicSlider;
    public Slider sfxSlider;

    public bool inGame = false;

    void Start()
    {
        LoadVolume();
        menu.gameObject.SetActive(false);

        Cursor.visible = !inGame;
        Debug.Log("Cursor is set to " + !inGame);
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
        if(inGame)
            Cursor.visible = true;
    }

    public void ResumeGame()
    {
        // Reanuda el juego y oculta el Canvas de Pausa
        Time.timeScale = 1f;
        menu.gameObject.SetActive(false);
        isPaused = false;
        if (inGame)
            Cursor.visible = false;
        SaveVolume();
    }

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetVolumeSFX(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }

    public void SaveVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        audioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SaveVolume();
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
}
