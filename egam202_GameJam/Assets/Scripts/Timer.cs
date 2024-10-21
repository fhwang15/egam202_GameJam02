using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float timerNumber;

    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerNumber = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timerNumber -= Time.deltaTime;
        int min = Mathf.FloorToInt(timerNumber / 60);
        int sec = Mathf.FloorToInt(timerNumber % 60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
