using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    //public float gravityScale = 1.0f;
    
    public Rigidbody rb;

    private ConstantForce cForce; //custom gravity
    private Vector3 forceDirection; //choosing the direction of the force

    //float maxDistance = 0.5f;
    RaycastHit hit;

    public Inventory items;

    // Start is called before the first frame update
    void Start()
    {
        cForce = GetComponent<ConstantForce>();
        forceDirection = new Vector3(0, -10, 0);
        cForce.force = forceDirection;

        items = GetComponent<Inventory>();
        
    }


    // Update is called once per frame
    void Update()
    {
        forceDirection = new Vector3(items.xAxisgravity, items.yAxisgravity, items.zAxisgravity);
        cForce.force = forceDirection;

    }

    void detectWall()
    {
        
    }  



}
