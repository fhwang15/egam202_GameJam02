using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float jumping;
    float JumpForce;

    public float gravityScale = 1.0f;

    public static float globalGravity = -9.81f;


    float xAxis;
    float zAxis;

    Vector3 movement;

    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
        
        canJump = true;

    }

    // Update is called once per frame
    void Update()
    {

        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }

        Run();

    }


    private void FixedUpdate()
    {

        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
       
    }


    void Run()
    {
        movement = new Vector3 (xAxis, 0, zAxis) * speed;
        rb.velocity = movement;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumping, ForceMode.VelocityChange);
        canJump = false;
        
    }


    


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            Debug.Log("touching");

            canJump = true;
        }
    }


}
