using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Inventory WhenWallis;


    Rigidbody rb;
    public float speed; //��ü�� �����̴� �ӵ��� �ٲܼ����� ��!!! ���
    public float jumping; //������ ������ �ٲܼ����� ��!!! ���

    public float rotateSpeed; //�̰� �Ⱦ��°� ������ ��������


    public GameObject[] PlatformSide; //�̰� �ٷ� 90�� ������ ������ �츮�� ����� �߷��̴� �̸��� (��������)


    public float gravityScale = 1.0f;


    float xAxis;
    float zAxis;
    float yAxis;
    

    Vector3 movement;

    bool canJump;

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

        ApplyGravity();
    }

    void Run()
    {
        if (WhenWallis.Floor)
        {
            movement = new Vector3(xAxis, 0, zAxis) * speed; //change in value of the position of the object
            movement.y = rb.velocity.y; //jump depends on the rigidbody of the obejct;

            if (!(xAxis == 0 && zAxis == 0))
            {
                Quaternion newRotation = Quaternion.LookRotation(movement);
                rb.MoveRotation(newRotation);
                //Player character turns towards the side they are looking at.
            }

        }

        else if (WhenWallis.Left) 
        {
            movement = new Vector3(0, -xAxis, zAxis) * speed; //change in value of the position of the object
            movement.x = rb.velocity.x; //jump depends on the rigidbody of the obejct;

            if (movement != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(movement);
                rb.MoveRotation(newRotation); // ĳ���Ͱ� �ٶ󺸴� �������� ȸ��
            }
           

        }

        else if (WhenWallis.Right)
        {
            movement = new Vector3(0, xAxis, zAxis) * speed; //change in value of the position of the object
            movement.x = rb.velocity.x; //jump depends on the rigidbody of the obejct;

            if (movement != Vector3.zero)
            {
                Quaternion newRotation = Quaternion.LookRotation(movement);
                rb.MoveRotation(newRotation); // ĳ���Ͱ� �ٶ󺸴� �������� ȸ��
            }


        }


        rb.velocity = movement; //change in position

    }

    void Jump()
    {

        rb.AddForce(Vector3.up * jumping, ForceMode.Impulse);
        canJump = false;
        
    }


    void ApplyGravity()
    {
        // Inventory���� �߷� ���� �����ͼ� ����
        float xAxisgravity = WhenWallis.xAxisgravity;
        float yAxisgravity = WhenWallis.yAxisgravity;
        float zAxisgravity = WhenWallis.zAxisgravity;

        // ���� �߷� ����
        Vector3 gravity = new Vector3(xAxisgravity, yAxisgravity, zAxisgravity);
        rb.AddForce(gravity * gravityScale);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            canJump = true;
            
        }
    }


}
