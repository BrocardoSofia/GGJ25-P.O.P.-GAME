using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSystem : MonoBehaviour

{
    public int level;
    public int totalEnemiesInLevel; //total enemies in the level
    public float currentXp;
    public float requiredXP;
    public float xpGained = 10f; // 10xp per enemy

    private float lerpTimer;
    private float delayTimer;
    [Header("UI")]
    public Image frontXpBar;
    public Image backXpBar;

    private int enemigosMuertos = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        requiredXP = totalEnemiesInLevel * xpGained; 
        frontXpBar.fillAmount = currentXp / requiredXP;
        backXpBar.fillAmount = currentXp / requiredXP;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateXpUI();
        if (Input.GetKeyDown(KeyCode.P))
        {
            GainExperienceFlatRate(); //ver
        }

        if(currentXp > requiredXP)
        {
            LevelUp();
        }

        if (enemigosMuertos == totalEnemiesInLevel)
        {
            LevelLogic.NextScene();
        }

    }

    public void UpdateXpUI()
    {
        float xpFraction = currentXp / requiredXP;
        float FXP = frontXpBar.fillAmount;

        if(FXP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            backXpBar.fillAmount = xpFraction;

            if(delayTimer > 2)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 4;
                frontXpBar.fillAmount = Mathf.Lerp(FXP, backXpBar.fillAmount, percentComplete);
            }
        }
     
    }

    public void GainExperienceFlatRate()
    {
        currentXp += xpGained;
        lerpTimer = 0f;
        enemigosMuertos++;
    }

    public void GainExperienceScalable(float xpGained, int passedLevel)
    {
        if (passedLevel < level)
        {
            float multiplier = 1 + (level - passedLevel * 1f);
            currentXp += xpGained * multiplier;
        }
        else
        {
            currentXp += xpGained;
        }
        lerpTimer = 0f;
        delayTimer = 0f;
    }

    public void LevelUp() // function resets the XP bars, calculates the leftover experience after leveling up, and rewards the player by increasing their health
    {
        frontXpBar.fillAmount = 0f;
        backXpBar.fillAmount = 0f;
        LevelLogic.NextScene();
    }

}
