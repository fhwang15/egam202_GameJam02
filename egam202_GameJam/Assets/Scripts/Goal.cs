using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{

    public bool win;

    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;



    // Start is called before the first frame update
    void Start()
    {
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (target.currentScore == 3)
        {
            win = true;
        }
        else if (target.currentScore < 3)
        {
            win = false;
        }

        else if (Timer.timerNumber < 0) 
        {
            Time.timeScale = 0;
            losing();
        }



    }

    public void winning()
    {
        winText.gameObject.SetActive(true);
    }

    public void losing()
    {
        loseText.gameObject.SetActive(true);
    }

    


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player") 
        {
            Time.timeScale = 0;

            if (win)
            {
                winning();
            }
            else
            {
                losing();
            }
        }
    }

}
