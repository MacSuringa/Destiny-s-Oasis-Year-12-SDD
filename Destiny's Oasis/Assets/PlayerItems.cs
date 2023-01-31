using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public GameObject itemMenuUI;

    public GameObject[] itemPrefabs;

    private float timer = 0f;
    private float timeStart;
    public float interval;

    public float interactRange = 2f;

    private float chance;
    public float chanceSuccess = 0.1f;

    // Update is called once per frame
    void Update()
    {
        itemSpawn();

        itemGrab();
    }

    private void itemSpawn()
    {
        timer += Time.deltaTime;

        if(timer >= interval)
        {
            timeStart = Time.timeSinceLevelLoad;
            timer = 0f;

            if (timeStart >= 0)
            {
                chance = Random.Range(0f, 1f);
                
                if(chance <= chanceSuccess)
                {
                    int itemType = Random.Range(0, itemPrefabs.Length);
                    spawnSystem(itemType);
                }
            }
        }
    }

    private void itemGrab()
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, interactRange);
        foreach (Collider2D collider in colliderArray)
        {
            if (collider.gameObject.tag =="Item")
            {
                Debug.Log(collider);
            }
        }
    }

    private void spawnSystem(int item)
    {
        float min_itemY = Camera.main.ViewportToWorldPoint(new Vector3(0, -1f, 0)).y;
        float max_itemY = Camera.main.ViewportToWorldPoint(new Vector3(0, 2f, 0)).y;

        float min_itemX = Camera.main.ViewportToWorldPoint(new Vector3(-1f, 0f, 0f)).x;
        float max_itemX = Camera.main.ViewportToWorldPoint(new Vector3(2f, 0f, 0f)).x;

        float spawn_x = Random.Range(min_itemX, max_itemX);
        float spawn_y = Random.Range(min_itemY, max_itemY);

        Instantiate(itemPrefabs[item], (new Vector3(spawn_x, spawn_y, 0f)), transform.rotation);
    }
}
