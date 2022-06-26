using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    public float healthAmount = 100;

    private void Update()
    {
        if (healthAmount <= 0)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(20);
        }

    }

    public void TakeDamage(float Damage)
    {
        healthAmount -= Damage;
    }

}
