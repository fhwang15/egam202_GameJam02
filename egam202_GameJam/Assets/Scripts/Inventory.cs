using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public Items currentState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case Items.Default:
                break;
            case Items.Lighter:

                break;
            case Items.Heavier:

                break;
            case Items.ChangeGravity:

                break;
        }
    }

    void DefaultState()
    {
       
    }

    void LighterState()
    {

    }

    void HeavierState()
    {

    }


    void ChangeGravity()
    {

    }

}
