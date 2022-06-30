using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100;

    public GameObject gameOver;

    private void Update()
    {
        if (healthAmount <= 0)
        {
            gameOver.SetActive(true);
        }
    }

    // function to simulate taking damage from enemies, to be called by enemy classes
    public void TakeDamage(int Damage)
    {
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 100;
    }

    // class to simulate healing, to be called in levelling
    public void Healing()
    {
        float healPoints = healthAmount * 0.1f;
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100;
    }
}
