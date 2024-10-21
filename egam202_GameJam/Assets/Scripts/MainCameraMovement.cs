using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;

public class MainCameraMovement : MonoBehaviour
{
    public Camera MyCamera;

    public GameObject Target;


    public float cameraX;
    public float cameraY;
    public float cameraZ;

    float CameraSpeed;

    Vector3 TargetPos;


    // Start is called before the first frame update
    void Start()
    {
        cameraY = 8.0f; //Camera should be away from the target itself
        cameraZ = 12.0f;

        CameraSpeed = 10.0f;

       

    }

    private void FixedUpdate()
    {
        TargetPos = new Vector3(Target.transform.position.x + cameraX, Target.transform.position.y + cameraY, Target.transform.position.z + cameraZ);
        transform.position = Vector3.Lerp(transform.position, TargetPos, Time.deltaTime * CameraSpeed);
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
