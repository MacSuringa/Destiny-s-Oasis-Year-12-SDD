using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100;
    public float healthAmountMax = 100;

    public GameObject gameOver;

    private void Update()
    {
        if (healthAmount <= 0)
        {
            Time.timeScale = 0f;
            gameOver.SetActive(true);
        }
    }

    // function to simulate taking damage from enemies, to be called by enemy classes
    public void TakeDamage(int Damage)
    {
        healthAmount -= Damage;
        //reduces the health points by the damage take

        healthBar.fillAmount = healthAmount / healthAmountMax;
        //adjusts how full the healthbar is based on a percentage
    }

    // class to simulate healing, to be called in levelling
    public void Healing()
    {
        if (healthAmount < healthAmountMax * 0.25)
        {
            float healPoints = healthAmountMax * 0.25f;
            healthAmount += healPoints;


            healthBar.fillAmount = healthAmount / healthAmountMax;
        }

        else
        {
            healthAmount = healthAmountMax;
            healthBar.fillAmount = 1;
        }
    }
}
