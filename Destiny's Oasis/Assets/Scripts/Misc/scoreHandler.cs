using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreHandler : MonoBehaviour
{
    public static int killAmount;
    public float timeAmount;
    public float timeAmountM;
    public int playerLevel;

    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        killAmount = 0;
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<playerExperience>().playerLevel;
    }

    // Update is called once per frame
    void Update()
    {
        timeAmount = Time.timeSinceLevelLoad;
        timeAmountM = Mathf.FloorToInt(timeAmount / 60);
        timeAmount = timeAmount % 60;

        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<playerExperience>().playerLevel;

        scoreText.text = "Level = " + playerLevel + "\nKills  = " + killAmount + "\nTime Survived = " + (int)timeAmountM + ":" + (int)timeAmount;
    }

    public static void killCounter()
    {
        killAmount += 1;
    }
}
