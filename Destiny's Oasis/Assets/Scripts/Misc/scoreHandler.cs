using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreHandler : MonoBehaviour
{
    public static int killAmount;
    private static float startTime;
    public float timeAmount;

    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        killAmount = 0;
        startTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeAmount = Time.time - startTime;
        scoreText.text = "Kills  = " + killAmount + "\nTime Survived = " + (int)timeAmount + " Seconds";
    }

    public static void killCounter()
    {
        killAmount += 1;
    }
}
