using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{

    public GameObject[] enemyPrefabs;

    public float interval;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if(timer >= interval)
        {
            timer = 0f;
            interval -= interval / 100;
            int randEnemy = Random.Range(0, enemyPrefabs.Length);

            float min_enemyY = Camera.main.ViewportToWorldPoint(new Vector3(0f, -1f, Camera.main.nearClipPlane)).y;
            float max_enemyY = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, Camera.main.nearClipPlane)).y;

            float min_enemyX = Camera.main.ViewportToWorldPoint(new Vector3(-1f, 0f, 0f)).x;
            float max_enemyX = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 0f)).x;

            float spawn_x = Random.Range(min_enemyX, max_enemyX);
            float spawn_y = Random.Range(min_enemyY, max_enemyY);

            Instantiate(enemyPrefabs[randEnemy], (new Vector3(spawn_x, spawn_y, 0f)), transform.rotation);
        }
    }
}
