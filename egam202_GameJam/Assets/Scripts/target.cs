using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class target : MonoBehaviour
{

    public static int currentScore;
    public static bool targethitted;

    public MeshRenderer myMaterial;


    bool hitted;

    private target Delievered;

    public Camera targetCamera;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        hitted = false;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentScore);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !hitted)
        {
            currentScore++;
            hitted = true;

            myMaterial.color = Color.yellow;

        }

       
    }

}
