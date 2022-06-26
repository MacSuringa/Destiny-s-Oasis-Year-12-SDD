using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerExperience : MonoBehaviour
{
    public Image experienceBar;

    private float Experience = 0f;
    public int playerLevel = 0;
    public float levelUpThreshold = 100f;

    public GameObject levelUpScreen;

    private void Update()
    {
        if (Experience >= levelUpThreshold)
        {
            levelUp();
        }

        experienceBar.fillAmount = Experience / levelUpThreshold;
    }

    public void gainXP(float enemyXP)
    {
        Experience += enemyXP;
        experienceBar.fillAmount = Experience / levelUpThreshold;
    }

    private void levelUp()
    {
        experienceBar.fillAmount = 0;
        Experience = 0;
        playerLevel += 1;
        levelUpThreshold *= 1.1f;

        levelUpScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Health()
    {
        gameObject.GetComponent<playerHealth>().healthAmount += 25;

        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Speed()
    {
        gameObject.GetComponent<Player_Controls>().moveSpeed += 5;

        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Damage()
    {
        gameObject.GetComponent<Player_Controls>().Damage += 25;

        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Radius()
    {
        gameObject.GetComponent<Player_Controls>().attackRadius += 5;

        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Cooldown()
    {
        gameObject.GetComponent<Player_Controls>().TimeStunned -= gameObject.GetComponent<Player_Controls>().TimeStunned * 0.9f;

        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }

}
