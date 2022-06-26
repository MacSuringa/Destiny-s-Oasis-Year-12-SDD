using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    Collider2D collider;
    public int Damage = 100;

    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (collider == Physics2D.OverlapPoint(mousePos))
            {
                GetComponent<enemyHealth>().TakeDamage(Damage);
            }
        }
    }
}