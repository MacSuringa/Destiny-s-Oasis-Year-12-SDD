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

    public GameObject attackAnimation;
    private Color attackColor = Color.cyan;

    private Color playerColor = Color.white;

    private void Start()
    {
            Color attackColor = attackAnimation.GetComponent<SpriteRenderer>().color;
            Color playerColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        if (Experience >= levelUpThreshold)
        {
            levelUp();
        }

        experienceBar.fillAmount = Experience / levelUpThreshold;
        attackAnimation.GetComponent<SpriteRenderer>().color = attackColor;
        gameObject.GetComponent<SpriteRenderer>().color = playerColor;
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
        gameObject.GetComponent<playerHealth>().Healing();

        levelUpScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Health()
    {
        gameObject.GetComponent<playerHealth>().healthAmount += 25;
        gameObject.GetComponent<playerHealth>().healthAmountMax += 25;

        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;

        playerColor = (playerColor + Color.red) / 2;
    }

    public void Speed()
    {
        gameObject.GetComponent<Player_Controls>().moveSpeed += 5;

        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;

        playerColor = (playerColor + Color.green) / 2;
    }

    public void Damage()
    {
        gameObject.GetComponent<Player_Controls>().Damage += 25;

        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;

        attackColor = (attackColor + Color.red) / 2;
    }

    public void Radius()
    {
        gameObject.GetComponent<Player_Controls>().attackRadius += 5;

        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;

       attackColor = (attackColor + Color.blue) / 2;
    }

    public void Cooldown()
    {
        gameObject.GetComponent<Player_Controls>().TimeStunned *= 0.9f;

        levelUpScreen.SetActive(false);
        Time.timeScale = 1f;

        attackColor = (attackColor + Color.green) / 2;
    }

}
