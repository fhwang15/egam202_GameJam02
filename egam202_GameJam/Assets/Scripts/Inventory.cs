using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

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

    public float yAxisgravity; //����
    public float xAxisgravity; //�ù�
    public float zAxisgravity; //�ʹ����巯��


    public bool Left;
    public bool Right;
    public bool Floor;

    // ������ floor�� left�� �ִ¼�ġ�� �ƴϸ� ���� ����... (���!)

    public float lighterGrav; //�ѹ���?

    public float distanceDetector; //��������

    public bool Walldetected;

    // Start is called before the first frame update
    void Start()
    {

        Floor = true; //���� ����Ʈ�δ� ���ٴڿ� �پ������ž���
        Left = false; //�̰� ���� �߷��� ������ �ٲ����� ����� �ɰ��� �÷ξ false�� �Ǹ鼭 ��ݵǰ� �ٸ��� ��.��.
        Right = false;


    }

    // Update is called once per frame
    void Update()
    {

        currentItem.text = "Current Mode: " + currentState.ToString();

        //changing the mode
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
        if (Floor)
        {
            //Very Default, the gravity is towards downside.
            xAxisgravity = 0;
            yAxisgravity = -10f;
            zAxisgravity = 0;

            //��... �̰� �Ѳ����� ���°� ����? ���߿� ã������-
        }
        else if (Left)
        {
            xAxisgravity = -10f; //����... ���� �װŴ� �� �ٱ�������
            yAxisgravity = 0; //�츮�� ��������� ���� '�Ʒ�'�� ���ϴ� �� (�����⸦ �����ιٲٴ���!)
            zAxisgravity = 0; //�� ���� (�����ʿ� ���ϰ̴ϴ�)

        }
        else if (Right) 
        { 
        
        //�� ��ٷ��� �� ���尥�����
        
        }



    }

    void LighterState()
    {
        if (Floor)
        {
            //Very Default, the gravity is towards downside.
            xAxisgravity = 0;
            yAxisgravity = -5f;
            zAxisgravity = 0;

            //��... �̰� �Ѳ����� ���°� ����? ���߿� ã������-
        }
        else if (Left)
        {
            xAxisgravity = -10f; //����... ���� �װŴ� �� �ٱ�������
            yAxisgravity = 0; //�츮�� ��������� ���� '�Ʒ�'�� ���ϴ� �� (�����⸦ �����ιٲٴ���!)
            zAxisgravity = 0; //�� ���� (�����ʿ� ���ϰ̴ϴ�)

        }
        else if (Right)
        {

            //�� ��ٷ��� �� ���尥�����

        }
    }

    void HeavierState()
    {
        if (Floor)
        {
            //Very Default, the gravity is towards downside.
            xAxisgravity = 0;
            yAxisgravity = -30f;
            zAxisgravity = 0;

            //��... �̰� �Ѳ����� ���°� ����? ���߿� ã������-
        }
        else if (Left)
        {
            xAxisgravity = -50f; //����... ���� �װŴ� �� �ٱ�������
            yAxisgravity = 0; //�츮�� ��������� ���� '�Ʒ�'�� ���ϴ� �� (�����⸦ �����ιٲٴ���!)
            zAxisgravity = 0; //�� ���� (�����ʿ� ���ϰ̴ϴ�)

        }
        else if (Right)
        {

            //�� ��ٷ��� �� ���尥�����

        }
    }


    void ChangeGravity()
    {
        DefaultState();

        RaycastHit hitinfo;

        //detect which side it is
        if(Physics.Raycast(transform.position, transform.forward, out hitinfo, distanceDetector))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (hitinfo.collider.gameObject.CompareTag("LeftWall"))
                {
                    Floor = false; 
                    Left = true; 
                    Right = false;

                }
                else if (hitinfo.collider.gameObject.CompareTag("RightWall"))
                {
                    Floor = false;
                    Left = false;
                    Right = true;
                }
                else if (hitinfo.collider.gameObject.CompareTag("floor"))
                {
                    Floor = true;
                    Left = false;
                    Right = false;
                }

                currentState = 0;
            }
        } 
        
        else
        {
            Debug.Log("undetected");
        }

        Debug.DrawRay(transform.position, transform.forward, Color.red, 1);

    }

}
