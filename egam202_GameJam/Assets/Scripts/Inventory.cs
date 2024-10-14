using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

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
        gravity = -300f;
    }

    void LighterState()
    {
        gravity = -150f;
    }

    void HeavierState()
    {
        
    }


    void ChangeGravity()
    {

    }

}
