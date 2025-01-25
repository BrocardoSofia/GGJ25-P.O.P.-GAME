using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialLogic : MonoBehaviour
{
    [SerializeField] 
    public Sprite[] tutorialImages;
    [SerializeField]
    public GameObject panel;
    private int index = 0;
    private Image panelImage;

    private void Start()
    {
        panelImage = panel.GetComponent<Image>();
        panelImage.sprite = tutorialImages[index];
    }

    public void ContinueTutorial()
    {
        if(index != (tutorialImages.Length - 1))
        {
            index++;
            if (index < tutorialImages.Length)
            {
                panelImage.sprite = tutorialImages[index];
            }
            else
            {
                StartGame();
            }
        }
       
    }

    public void PreviousTutorial()
    {
        if(index != 0)
        {
            index--;
            if (index >= 0)
            {
                panelImage.sprite = tutorialImages[index];
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
