using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float jumping;

    public float rotateSpeed;

    float JumpForce;
    public ForceMode PlayerJump;


    // public float gravityScale = 1.0f;

    //public Items currentState;

    float xAxis;
    float zAxis;
    

    Vector3 movement;

    bool canJump;

    Items item;

    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;

        

    }

    // Update is called once per frame
    void Update()
    {

        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        Run();

        if (Input.GetKeyDown(KeyCode.Space) && canJump) //if the playercharacter is on the floor that is when you can jump.
        {
            Jump();        
        }

       

    }

    void Run()
    {
     
        movement = new Vector3 ((-1*zAxis), 0, xAxis) * speed; //change in value of the position of the object

        if(!(xAxis == 0 && zAxis == 0))
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            rb.MoveRotation(newRotation);

            //Player character turns towards the side they are looking at.

        }

        movement.y = rb.velocity.y; //jump depends on the rigidbody of the obejct;
        
        rb.velocity = movement; //change in position


    }

    void Jump()
    {

        rb.AddForce(Vector3.up * jumping, PlayerJump);
        canJump = false;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            
            canJump = true;
            
        }
    }


}
