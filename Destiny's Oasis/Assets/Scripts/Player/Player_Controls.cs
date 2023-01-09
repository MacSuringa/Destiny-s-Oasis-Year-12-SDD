using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controls : MonoBehaviour
{
    public float moveSpeed = 50f;
    // Gets a modifiable variable with a default value of 5

    public Rigidbody2D rb;
    // Gets data from the rigid body component

    public Animator animator;
    // enables animation data from the inbuilt Animator

    public Camera MainCam;
    // Gets data from the camera

    public int Damage = 100;
    // sets the amount of damage the player deals

    private bool isStunned = false;

    public float TimeStunned = 1.5f;

    private float isStunnedTimer = 0f;

    public float attackRadius = 24f;

    public GameObject attackAnimation;

    public Image cooldownBar;

    Vector2 movement;
    Vector2 mousePos;
    Vector2 strikePos;
    // defines variables with no value

    void Update()
    // Update is called once per frame
    {

        //when the character isnt stunned (paused becuase they are making their attack etc)
        if (!(isStunned))
        {
            //function for movement
            Movement();

            //function for the attack
            Attack();
        }

        mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        // gets the mouses position based on the location screen (what the camera sees)

        UpdateTimer();
    }

    void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        // Gets horizontal and vertical input, and adds them to the movement variable

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        // moves the player body based on the movement type, speed and time
    }

    void UpdateTimer()
    {
        if (isStunned == true)
        {
            // removes part of the stun duration each frame until the variable is false again
            isStunnedTimer += Time.deltaTime;
            if (isStunnedTimer >= TimeStunned)
            {
                isStunned = false;
            }

            cooldownBar.fillAmount = isStunnedTimer / TimeStunned;
        }

    }

    void Attack()
    {
        if (Time.timeScale == 1f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                strikePos = new Vector2(mousePos.x + 1, mousePos.y + 58);
                Instantiate(attackAnimation, strikePos, attackAnimation.transform.rotation);

                isStunned = true;
                isStunnedTimer = 0f;
            }
        }
    }

    public void Lightning()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(strikePos.x - 1, strikePos.y - 58), attackRadius);


        foreach (Collider2D c in colliders)
        {
            if (c.GetComponent<enemyHealth>())
            {
                c.GetComponent<enemyHealth>().TakeDamage(Damage);
            }
        }
    }
}