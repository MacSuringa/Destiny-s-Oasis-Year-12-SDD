using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy_Spawn : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    public Color[] tileColor;

    public Tilemap tilemap;

    public float interval;
    private float timer = 0f;
    private int intervalCount = 1;

    private int eventType;

    private float specialTimer = 0f;
    private float specialInterval = 30f;
    private bool colorChange = false;

    private float specialDuration = 10f;
    private float specialCountDown = 0f;

    private float eventSpawnRate = 1f;
    private float eventSpawnCooldown = 0f;

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
            interval -= interval / 10;

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
                tilemap.color = tileColor[eventType];

                colorChange = true;
            }

            specialCountDown += Time.deltaTime;

            if (specialCountDown >= specialDuration)
            {
                specialInterval += specialInterval * 0.05f;

                colorChange = false;

                specialTimer = 0;
                specialCountDown = 0;

                tilemap.color = Color.white;
            }

            eventSpawnCooldown += Time.deltaTime;

            if (eventSpawnCooldown >= eventSpawnRate)
            {
                if (colorChange)
                {
                    spawnSystem(eventType);

                    eventSpawnCooldown = 0f;
                }

            }
        }
    }

    private void spawnSystem(int enemy)
    {
        float min_enemyY = Camera.main.ViewportToWorldPoint(new Vector3(0f, Camera.main.nearClipPlane, -1f)).y;
        float max_enemyY = Camera.main.ViewportToWorldPoint(new Vector3(0f, Camera.main.nearClipPlane, 1f)).y;

        float min_enemyX = Camera.main.ViewportToWorldPoint(new Vector3(-1f, 0f, 0f)).x;
        float max_enemyX = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;

        float spawn_x = Random.Range(min_enemyX, max_enemyX);
        float spawn_y = Random.Range(min_enemyY, max_enemyY);

        Instantiate(enemyPrefabs[enemy], (new Vector3(spawn_x, spawn_y, 0f)), transform.rotation);
    }
}
