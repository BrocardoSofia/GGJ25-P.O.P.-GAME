using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public AudioSource SFXSource;

    public AudioClip damageSound;

    private float health;
    private float lerpTimer;

    public float maxHealth = 100;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;
    public TextMeshProUGUI healthText;
    [SerializeField] private GameObject manchaDeSangre;
    private bool manchaDeSangreActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        updateHealthUI();

        if (health <= 0)
        {
            LevelLogic.GameOver();
        }

    }

    public void updateHealthUI()
    {
        float fillFront = frontHealthBar.fillAmount;
        float fillBack = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;

        if (fillBack > hFraction) //taken damage
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillBack, hFraction, percentComplete);
        }

        if (fillFront < hFraction)
        {
            backHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.green;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillFront, backHealthBar.fillAmount, percentComplete);
        }
        healthText.text = Mathf.Round(health) + "/" + Mathf.Round(maxHealth);
    }
    

    public void takeDamage(float damage)
    {
        manchaDeSangre.SetActive(true);
        manchaDeSangreActive = true;
        SFXSource.PlayOneShot(damageSound);
        health -= damage;
        lerpTimer = 0f;

        if (manchaDeSangreActive)
        {
            manchaDeSangreActive = false;
            Invoke("desactivarManchaDeSangre", 2f);
        }
    }

    private void desactivarManchaDeSangre()
    {
        manchaDeSangre.SetActive(false);
    }

    public void restoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
    }

    public void IncreaseHealth(int scaleFactor) //is called when the player levels up, ensuring their maximum health increases as a reward and their current health is fully restored.
    {
        maxHealth += (health * 0.01f) * ((100 - scaleFactor) * 0.1f);
        health = maxHealth;
    }
    
}
