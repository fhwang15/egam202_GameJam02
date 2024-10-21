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

    public float yAxisgravity; //흑흑
    public float xAxisgravity; //시바
    public float zAxisgravity; //너무힘드러잇


    public bool Left;
    public bool Right;
    public bool Floor;

    // 당장은 floor랑 left만 있는셈치셈 아니면 님이 뒤짐... (충격!)

    public float lighterGrav; //닌뭐임?

    public float distanceDetector; //감지범위

    public bool Walldetected;

    // Start is called before the first frame update
    void Start()
    {

        Floor = true; //가장 디폴트로는 땅바닥에 붙어있으셔야해
        Left = false; //이게 이제 중력의 방향을 바꿨을때 토글이 될거임 플로어가 false가 되면서 잠금되고 다른게 해.방.
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

            //아... 이거 한꺼번에 묶는거 없나? 나중에 찾으셈ㄱ-
        }
        else if (Left)
        {
            xAxisgravity = -10f; //음냐... 뭐냐 그거다 그 바깥오른쪽
            yAxisgravity = 0; //우리가 통상적으로 보는 '아래'로 향하는 힘 (쓰레기를 나무로바꾸는힘!)
            zAxisgravity = 0; //닌 뭔데 (오른쪽에 쓰일겁니다)

        }
        else if (Right) 
        { 
        
        //넌 기다려라 이 맞장갈새기야
        
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

            //아... 이거 한꺼번에 묶는거 없나? 나중에 찾으셈ㄱ-
        }
        else if (Left)
        {
            xAxisgravity = -10f; //음냐... 뭐냐 그거다 그 바깥오른쪽
            yAxisgravity = 0; //우리가 통상적으로 보는 '아래'로 향하는 힘 (쓰레기를 나무로바꾸는힘!)
            zAxisgravity = 0; //닌 뭔데 (오른쪽에 쓰일겁니다)

        }
        else if (Right)
        {

            //넌 기다려라 이 맞장갈새기야

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

            //아... 이거 한꺼번에 묶는거 없나? 나중에 찾으셈ㄱ-
        }
        else if (Left)
        {
            xAxisgravity = -50f; //음냐... 뭐냐 그거다 그 바깥오른쪽
            yAxisgravity = 0; //우리가 통상적으로 보는 '아래'로 향하는 힘 (쓰레기를 나무로바꾸는힘!)
            zAxisgravity = 0; //닌 뭔데 (오른쪽에 쓰일겁니다)

        }
        else if (Right)
        {

            //넌 기다려라 이 맞장갈새기야

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
