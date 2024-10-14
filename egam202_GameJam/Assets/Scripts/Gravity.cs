using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    //public float gravityScale = 1.0f;
    
    public Rigidbody rb;

    private ConstantForce cForce;
    private Vector3 forceDirection;


    // Start is called before the first frame update
    void Start()
    {
        cForce = GetComponent<ConstantForce>();
        forceDirection = new Vector3(0, -10, 0);
        cForce.force = forceDirection;
    }


    // Update is called once per frame
    void Update()
    {
        //OnDrawGizmos();
    }

    //void OnDrawGizmos()
    //{
    //    float maxDistance = 1;
    //    RaycastHit hit;
        
    //    bool isHit = Physics.BoxCast(transform.position, transform.lossyScale, transform.forward, out hit, transform.rotation, maxDistance);

    //    Gizmos.color = Color.red;
    //    if (isHit)
    //    {
    //        Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
    //        Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, transform.lossyScale);
    //    }
    //    else
    //    {
    //        Gizmos.DrawRay(transform.position, transform.forward * maxDistance);
    //    }

    //}


  
}
