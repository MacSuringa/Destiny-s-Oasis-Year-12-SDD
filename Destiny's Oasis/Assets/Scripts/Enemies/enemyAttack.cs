using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    //defines a variable for damage that can be updated outside of the script
    public int Damage = 5;

    // function that checks object collision with Collider2D components
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks if this object collided with a specific tagged object
        if (collision.gameObject.CompareTag("Player"))
        {
            //finds an object from the GameObject class, that has the tag 'Player' (such as PlayerSquare, with its tag of Player), then 
            //gets the script for player health, then runs the function through that object, with set parameters.
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>().TakeDamage(Damage);
        }
    }
}
