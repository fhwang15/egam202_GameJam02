using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public enum Items
{
    Default,
    Lighter,
    Heavier,
    ChangeGravity
}

public class Inventory : MonoBehaviour
{

    public TextMeshProUGUI currentItem;

    public Items currentState;

    public float yAxisgravity; //
    public float xAxisgravity; //
    public float zAxisgravity; //


    public float lighterGrav;

    public float distanceDetector;

    public bool Walldetected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        currentItem.text = "Current Mode: " + currentState.ToString();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentState++;

            if((int)currentState > 3)
            {
                currentState = 0;
            }
        }

        switch (currentState)
        {
            case Items.Default:
                DefaultState();
                break;
            case Items.Lighter:
                LighterState();
                break;
            case Items.Heavier:
                HeavierState();
                break;
            case Items.ChangeGravity:
                ChangeGravity();
                break;
        }
    }

    void DefaultState()
    {
        yAxisgravity = -10f;
    }

    void LighterState()
    {
        yAxisgravity = -5f;
    }

    void HeavierState()
    {
        yAxisgravity = -20f;
    }


    void ChangeGravity()
    {
        RaycastHit hitinfo;

        //detect which side it is
        if(Physics.Raycast(transform.position, transform.forward, out hitinfo, distanceDetector))
        {
            if (Input.GetKeyDown(KeyCode.X))
            {

                if (hitinfo.collider.gameObject.CompareTag("LeftWall"))
                {
                    Debug.Log(hitinfo.collider.gameObject.name);

                    yAxisgravity = 0;
                    xAxisgravity = 10;                    
                }
                else if (hitinfo.collider.gameObject.CompareTag("RightWall"))
                {

                }
                else if (hitinfo.collider.gameObject.CompareTag("floor"))
                {

                }
            }
        } 
        
        else
        {
            Debug.Log("undetected");
        }

        //yAxisgravity = -10f;


        Debug.DrawRay(transform.position, transform.forward, Color.red, 1);

        //if exist & press space, change gravity
       


    }

}
