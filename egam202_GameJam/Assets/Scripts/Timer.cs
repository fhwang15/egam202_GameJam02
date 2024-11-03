using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float timerNumber;

    public TextMeshProUGUI timerText;

    public GameObject lose;

    // Start is called before the first frame update
    void Start()
    {
        timerNumber = 60;
    }

    // Update is called once per frame
    void Update()
    {
        timerNumber -= Time.deltaTime;

        if(timerNumber < 0)
        {
            LoseGame();
        }

        timerNumber = Mathf.Max(0, timerNumber);

        int min = Mathf.FloorToInt(timerNumber / 60);
        int sec = Mathf.FloorToInt(timerNumber % 60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

    public void LoseGame()
    {
        lose.SetActive(true);
        Time.timeScale = 0f;
    }

}
