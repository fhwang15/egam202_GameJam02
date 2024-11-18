using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;

public enum GravityIntensity
{
    Default,
    Lighter,
    Heavier,
}

public class Inventory : MonoBehaviour
{

    public TextMeshProUGUI currentItem;
    public TextMeshProUGUI WallCheck;

    public GravityIntensity currentState;

    public float yAxisgravity;
    public float xAxisgravity;
    public float zAxisgravity;


    public bool Left;
    public bool Right;
    public bool Floor;

    Renderer thisRenderer;

    public Color defaultColor = Color.gray;
    public Color HeavierColor = Color.white;
    public Color LighterColor = Color.black;

    public Color detectedColor;


    RaycastHit hitinfo;
    public bool isDetected;

    public float distanceDetector; //감지범위

    // Start is called before the first frame update
    void Start()
    {

        WallCheck.enabled = false;

        thisRenderer = GetComponent<Renderer>();

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

            if ((int)currentState > 2)
            {
                currentState = 0;
            }
        }

        switch (currentState)
        {
            case GravityIntensity.Default:
                DefaultState();
                currentItem.color = defaultColor;
                break;
            case GravityIntensity.Lighter:
                LighterState();
                currentItem.color = LighterColor;
                break;
            case GravityIntensity.Heavier:
                HeavierState();
                currentItem.color = HeavierColor;
                break;
        }


        if (Physics.Raycast(transform.position, transform.forward, out hitinfo, distanceDetector))
        {
            thisRenderer.material.color = detectedColor;
            isDetected = true;
        } else
        {
            isDetected = false;
        }

        if (isDetected)
        {
            WallCheck.enabled = true;

            if (Input.GetKeyDown(KeyCode.X))
            {
                ChangeGravity();
            }
        } else if (!isDetected)
        {
            WallCheck.enabled = false;
        }


        void DefaultState()
        {
            thisRenderer.material.color = defaultColor;

            if (Floor)
            {
                SetGravity(0, -10, 0);
            }
            else if (Left)
            {
                SetGravity(-10, 0, 0);
            }
            else if (Right)
            {
                SetGravity(10, 0, 0);
            }


        }

        void LighterState()
        {
            thisRenderer.material.color = LighterColor;

            if (Floor)
            {
                SetGravity(0, -5f, 0);

            }
            else if (Left)
            {
                SetGravity(-5f, 0, 0);

            }
            else if (Right)
            {
                SetGravity(5f, 0, 0);

            }
        }

        void HeavierState()
        {
            thisRenderer.material.color = HeavierColor;

            if (Floor)
            {
                SetGravity(0, -30, 0);

            }
            else if (Left)
            {
                SetGravity(-30f, 0, 0);

            }
            else if (Right)
            {
                SetGravity(30f, 0, 0);
            }
        }


        void SetGravity(float x, float y, float z)
        {
            xAxisgravity = x;
            yAxisgravity = y;
            zAxisgravity = z;
        }


        void ChangeGravity()
        {
            //detect which side it is
            if (Physics.Raycast(transform.position, transform.forward, out hitinfo, distanceDetector))
            {
                if (hitinfo.collider.gameObject.CompareTag("LeftWall"))
                {
                    Debug.Log("왜안돼?");
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
            }
            else
            {
                thisRenderer.material.color = defaultColor;
            }

            currentState = 0;
            isDetected = false;
            thisRenderer.material.color = defaultColor;

            Debug.DrawRay(transform.position, transform.forward, Color.red, 1);

        }

    }
}
