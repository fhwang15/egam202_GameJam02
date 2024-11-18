using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class target : MonoBehaviour
{

    public static int currentScore;

    public Renderer myRend;


    public bool hitted;

    private target Delievered;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        hitted = false;

        

    }

    // Update is called once per frame
    void Update()
    {
      

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !hitted)
        {
            currentScore++;
            hitted = true;

            myRend.material.color = Color.yellow;
        }

       
    }

}
