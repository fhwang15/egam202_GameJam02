using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;

public class MainCameraMovement : MonoBehaviour
{

    public Inventory WhenWallis;

    public Camera MyCamera;   // 카메라
    public GameObject Target; // 타겟 (주인공 등)

    public float cameraDistance = 10.0f;  // 카메라와 타겟 사이의 거리
    public float cameraHeight = 5.0f;     // 카메라 높이
    public float cameraAngle = 45.0f;    // 카메라 각도 (쿼터뷰 각도)

    public float CameraSpeed = 10.0f;    // 카메라 이동 속도
    public float angleAdjustmentSpeed = 2f; // 카메라 각도 변경 속도

    Vector3 targetPos;

    void Start()
    {
        // 카메라 설정
        cameraHeight = 5.0f;
        cameraDistance = 10.0f;
        cameraAngle = 45.0f;
    }

    void FixedUpdate()
    {
        // 카메라가 타겟을 쫓아가게 설정
        // 카메라는 타겟 뒤쪽 위쪽에 위치하도록
        Vector3 direction = (Target.transform.position - transform.position).normalized;

        // 카메라의 목표 위치 계산
        float horizontalOffset = Mathf.Sin(Mathf.Deg2Rad * cameraAngle) * cameraDistance;
        float verticalOffset = Mathf.Cos(Mathf.Deg2Rad * cameraAngle) * cameraDistance;

        // 타겟 뒤쪽 위로 설정
        Vector3 targetPosition = Target.transform.position;
        Vector3 cameraPosition = targetPosition - Target.transform.forward * horizontalOffset + Vector3.up * cameraHeight + Target.transform.up * verticalOffset;

        // 카메라 이동
        transform.position = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime * CameraSpeed);

        // 카메라는 타겟을 바라봄
        transform.LookAt(Target.transform.position + Vector3.up * cameraHeight); // 타겟을 바라보되 위쪽으로 살짝 봄

        AdjustCameraAngle();
    }


    void AdjustCameraAngle()
    {
        // 중력 상태에 따라 카메라 각도 변경
        if (WhenWallis.Floor)
        {
            // 바닥에 있을 때 카메라 각도
            cameraAngle = Mathf.Lerp(cameraAngle, 45f, Time.deltaTime * angleAdjustmentSpeed);  // 45도
        }
        else if (WhenWallis.Left)
        {
            // 왼쪽 벽에 있을 때 카메라 각도
            cameraAngle = Mathf.Lerp(cameraAngle, 90f, Time.deltaTime * angleAdjustmentSpeed);  // 90도 (변경된 각도)
        }
        else if (WhenWallis.Right)
        {
            // 오른쪽 벽에 있을 때 카메라 각도
            cameraAngle = Mathf.Lerp(cameraAngle, 0f, Time.deltaTime * angleAdjustmentSpeed);  // 0도 (변경된 각도)
        }
    }
}
