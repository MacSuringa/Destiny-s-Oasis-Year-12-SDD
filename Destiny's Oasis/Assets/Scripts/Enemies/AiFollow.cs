using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFollow : MonoBehaviour
{
    public float speed;

    private GameObject player;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in currentEnemies)
        {
            float currentDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (currentDistance <= 1.5f)
            {
                Vector3 dist = transform.position - enemy.transform.position;
                transform.position += dist * Time.deltaTime;
            }
        }

        player = GameObject.FindWithTag("Player");

        //gets distance between the player and the object
        distance = Vector2.Distance(transform.position, player.transform.position);

        //gets direction and gets the normal for it
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        // gets the angle to the player in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        //makes the object move toward the player based on the set speed, also rotates it to face the player
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

    }
}
