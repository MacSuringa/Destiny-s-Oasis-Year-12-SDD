using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float healthAmount = 10;

    private void Update()
    {
        if (healthAmount <= 0)
        {
            Destroy(gameObject);
            scoreHandler.killCounter();
        }
    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
    }

}
