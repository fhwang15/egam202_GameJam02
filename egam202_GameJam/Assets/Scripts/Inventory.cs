using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public float gravity;
    public float lighterGrav;

   

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
        gravity = -500f;
    }

    void LighterState()
    {
        gravity = -300f;
    }

    void HeavierState()
    {
        gravity = -700f;
    }


    void ChangeGravity()
    {

    }

}
