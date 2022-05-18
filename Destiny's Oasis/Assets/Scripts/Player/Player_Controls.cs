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

    Vector2 movement;
    Vector2 mousePos;
    // defines variables with no value

    void Update()
    // Update is called once per frame
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        // Gets horizontal and vertical input, and adds them to the movement variable

        mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);
        // gets the mouses position based on the location screen (what the camera sees)
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
}