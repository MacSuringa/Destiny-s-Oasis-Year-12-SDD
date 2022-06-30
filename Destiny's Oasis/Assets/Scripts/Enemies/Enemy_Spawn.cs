using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Enemy_Spawn : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    public Color[] tileColor;

    public Tilemap tilemap;
    public Canvas canvas;
    private Image image;

    public float interval;
    private float timer = 0f;
    private int intervalCount = 1;

    private int eventType;

    private float specialTimer = 0f;
    public float specialInterval = 30f;
    private bool colorChange = false;

    public float specialDuration = 10f;
    private float specialCountDown = 0f;

    private float eventSpawnRate = 1f;
    private float eventSpawnCooldown = 0f;
    private int eventCount = 0;

    // Update is called once per frame
    void Update()
    {
        normalSpawn();

        eventCheck();

    }

    private void normalSpawn()
    {
        timer += Time.deltaTime;

        if(timer >= interval)
        {
            timer = 0f;
            interval -= interval / 60;

            if (interval <= 0.5)
            {
                interval = 3f;
                intervalCount += 1;
            }

            for (int i = 1 ; i <= intervalCount; i++)
            {
                int randEnemy = Random.Range(0, enemyPrefabs.Length);

                spawnSystem(randEnemy);
            }

        }
    }

    private void eventCheck()
    {
        specialTimer += Time.deltaTime;

        if (specialTimer >= specialInterval)
        {
            if (!colorChange)
            {
                eventType = Random.Range(0, tileColor.Length);

                changeColor(0.8f);

                tilemap.color = tileColor[eventType];

                colorChange = true;

                eventCount += 1;
            }

            specialCountDown += Time.deltaTime;

            if (specialCountDown >= specialDuration)
            {
                specialInterval += specialInterval * 0.05f;

                colorChange = false;

                specialTimer = 0;
                specialCountDown = 0;

                tilemap.color = Color.white;

                changeColor(0);
            }

            eventSpawnCooldown += Time.deltaTime;

            if (eventSpawnCooldown >= eventSpawnRate)
            {
                if (colorChange)
                {
                    for (int i = 0; i <= eventCount; i++)
                        spawnSystem(eventType);

                    eventSpawnCooldown = 0f;
                }

            }
        }
    }

    private void changeColor(float value)
    {
        image = canvas.GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = value;
        image.color = tempColor;
    }

    private void spawnSystem(int enemy)
    {
        float min_enemyY = Camera.main.ViewportToWorldPoint(new Vector3(0, -1f, 0)).y;
        float max_enemyY = Camera.main.ViewportToWorldPoint(new Vector3(0, 2f, 0)).y;

        float min_enemyX = Camera.main.ViewportToWorldPoint(new Vector3(-1f, 0f, 0f)).x;
        float max_enemyX = Camera.main.ViewportToWorldPoint(new Vector3(2f, 0f, 0f)).x;

        float spawn_x = Random.Range(min_enemyX, max_enemyX);
        float spawn_y = Random.Range(min_enemyY, max_enemyY);
        
        if (spawn_x >= Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x || spawn_x <= Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x)
        {
            float Chance = Random.value;

            if (Chance >= 0.5)
            {
                spawn_y = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, 1f, 0)).y, Camera.main.ViewportToWorldPoint(new Vector3(0f, 2f, 0)).y);
            }

            else
            {
                spawn_y = Random.Range(Camera.main.ViewportToWorldPoint(new Vector3(0, -1f, 0)).y, Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y);
            }

        }

        Instantiate(enemyPrefabs[enemy], (new Vector3(spawn_x, spawn_y, 0f)), transform.rotation);
    }
}
