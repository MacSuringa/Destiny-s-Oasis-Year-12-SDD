using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointHandler : MonoBehaviour
{
    public static int killAmount;
    public float timeAmount;
    public int playerLevel;

    private Text scoreText;

    private float timeScore;
    private float levelScore;
    private float killScore;

    void Start()
    {
        scoreText = GetComponent<Text>();
        killAmount = 0;
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<playerExperience>().playerLevel;
    }

    void Update()
    {
        timeAmount = Time.timeSinceLevelLoad;
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<playerExperience>().playerLevel;
        killAmount = scoreHandler.killAmount;

        timeScore = Mathf.Ceil(timeAmount / 15);
        levelScore = Mathf.Ceil(playerLevel / 2);
        killScore = Mathf.Ceil(killAmount / 5);

        scoreText.text = "+ " + levelScore + "\n+ " + killScore + "\n+ " + (int)timeScore;
    }

}
