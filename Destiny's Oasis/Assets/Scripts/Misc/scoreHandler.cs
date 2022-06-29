using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreHandler : MonoBehaviour
{
    public static int killAmount;
    public float timeAmount;
    public int playerLevel;

    private TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        killAmount = 0;
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<playerExperience>().playerLevel;
    }

    // Update is called once per frame
    void Update()
    {
        timeAmount = Time.timeSinceLevelLoad;
        playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<playerExperience>().playerLevel;

        scoreText.text = "Level = " + playerLevel + "\nKills  = " + killAmount + "\nTime Survived = " + (int)timeAmount + " Seconds";
    }

    public static void killCounter()
    {
        killAmount += 1;
    }
}
