using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{

    public GameObject[] enemyPrefabs;

    public float interval;
    private float timer = 0f;
    private int intervalCount = 1;

    // Update is called once per frame
    void Update()
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

                float min_enemyY = Camera.main.ViewportToWorldPoint(new Vector3(0f, Camera.main.nearClipPlane, -1f)).y;
                float max_enemyY = Camera.main.ViewportToWorldPoint(new Vector3(0f, Camera.main.nearClipPlane, 1f)).y;

                float min_enemyX = Camera.main.ViewportToWorldPoint(new Vector3(-1f, 0f, 0f)).x;
                float max_enemyX = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;

                float spawn_x = Random.Range(min_enemyX, max_enemyX);
                float spawn_y = Random.Range(min_enemyY, max_enemyY);

                Instantiate(enemyPrefabs[randEnemy], (new Vector3(spawn_x, spawn_y, 0f)), transform.rotation);
            }

        }
    }
}
