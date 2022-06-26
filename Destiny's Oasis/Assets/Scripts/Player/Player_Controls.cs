using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    public float moveSpeed = 5f;
    // Gets a modifiable variable with a default value of 5

    public Rigidbody2D rb;
    // Gets data from the rigid body component

    public Animator animator;
    // enables animation data from the inbuilt Animator

    public Camera MainCam;
    // Gets data from the camera

    private int Damage = 100;
    // sets the amount of damage the player deals

    private bool isStunned = false;

    public float TimeStunned = 1.5f;

    private float isStunnedTimer = 0f;

    public float attackRadius = 25f;

    Vector2 movement;
    Vector2 mousePos;
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

            mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
            // gets the mouses position based on the location screen (what the camera sees)

            UpdateTimer();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        // moves the player body based on the movement type, speed and time

        Vector2 lookDirect = mousePos - rb.position;
        // sets a variable to find the x and y axis value for where the player needs to face

        float angle = Mathf.Atan2(lookDirect.y, lookDirect.x) * Mathf.Rad2Deg - 90f;
        // gets the angle in radians for the player to face

        rb.rotation = angle;
        // rotates the player body based on said angle
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
        // removes part of the stun duration each frame until the variable is false again
        isStunnedTimer += Time.deltaTime;
        if (isStunnedTimer >= TimeStunned)
        {
            isStunned = false;
        }
    }

    void Attack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(mousePos, attackRadius);

        if (Input.GetMouseButtonDown(0))
        {
            foreach (Collider2D c in colliders)
            {
                if (c.GetComponent<enemyHealth>())
                {
                    c.GetComponent<enemyHealth>().TakeDamage(Damage);
                }
            }
            isStunned = true;
            isStunnedTimer = 0f;
        }
    }
}