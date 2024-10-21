using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Inventory invent;



    Rigidbody rb;
    public float speed; //��ü�� �����̴� �ӵ��� �ٲܼ����� ��!!! ���
    public float jumping; //������ ������ �ٲܼ����� ��!!! ���

    public float rotateSpeed; //�̰� �Ⱦ��°� ������ ��������


    Vector3 SideGravity; // �̰� ��¡
    public GameObject[] PlatformSide; //�̰� �ٷ� 90�� ������ ������ �츮�� ����� �߷��̴� �̸��� (��������)


    public float gravityScale = 1.0f;


    float xAxis;
    float zAxis;
    float yAxis;
    

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

        if (invent.Floor)
        {
            movement = new Vector3((-1 * zAxis), 0, xAxis) * speed; //change in value of the position of the object
            movement.y = rb.velocity.y; //jump depends on the rigidbody of the obejct;

            if (!(xAxis == 0 && zAxis == 0))
            {
                Quaternion newRotation = Quaternion.LookRotation(movement);
                rb.MoveRotation(newRotation);
                //Player character turns towards the side they are looking at.
            }

        }

        else if (invent.Left) 
        {
            movement = new Vector3(0, zAxis, xAxis) * speed; //change in value of the position of the object
            movement.x = rb.velocity.x; //jump depends on the rigidbody of the obejct;

            if (!(xAxis == 0 && zAxis == 0))
            {
                Quaternion newRotation = Quaternion.LookRotation(movement);
                rb.MoveRotation(newRotation);
                //Player character turns towards the side they are looking at.
            }

            LeftGravity();
        }

       

        rb.velocity = movement; //change in position

    }

    void Jump()
    {

        rb.AddForce(Vector3.up * jumping, ForceMode.Impulse);
        canJump = false;
        
    }


    void LeftGravity()
    {

        for (int i = 0; i < PlatformSide.Length; i++)
        {
            Vector3 direction = PlatformSide[i].transform.position - this.transform.position;

            direction.Normalize();
            this.rb.AddForce(direction * gravityScale);

        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            
            canJump = true;
            
        }
    }


}
