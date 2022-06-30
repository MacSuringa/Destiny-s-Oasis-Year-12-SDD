using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackAnimation : MonoBehaviour
{
    void damageEnemy()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controls>().Lightning();
    }

    void destroySprite()
    {
        Destroy(gameObject);
    }
}
