using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    //public float gravityScale = 1.0f;
    
    public Rigidbody rb;

    private ConstantForce cForce;
    private Vector3 forceDirection;

    float maxDistance = 0.5f;
    RaycastHit hit;

    public Inventory items;

    // Start is called before the first frame update
    void Start()
    {
        cForce = GetComponent<ConstantForce>();
        forceDirection = new Vector3(0, 0, 0);
        cForce.relativeForce = forceDirection;

        items = GetComponent<Inventory>();
        
    }


    // Update is called once per frame
    void Update()
    {
        forceDirection = new Vector3(0, items.gravity, 0);
        cForce.relativeForce = forceDirection;

    }

    void detectWall()
    {
        
            //hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            //items.currentState = Items.ChangeGravity;
        
    }  
}
