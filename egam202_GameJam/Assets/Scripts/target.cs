using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    float chances;

    public static bool targethitted;

    private target Delievered;

    public Camera targetCamera;

    // Start is called before the first frame update
    void Start()
    {
        chances = 3;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            chances = chances - 1;

            Vector2 mouseposition = Input.mousePosition;
            Ray worldRay = targetCamera.ScreenPointToRay(mouseposition);

            

            if (Physics.Raycast(worldRay, out RaycastHit hitInfo))
            {
                

                target Delivery = hitInfo.transform.gameObject.GetComponent<target>();

                Debug.Log(Delivery);
                

                if (Delivery != null && chances > 0)
                {
                    targethitted = true;
                }

                else if (chances == 0)
                {
                    Time.timeScale = 0;
                }


            }

            
        }
        
    }
}
