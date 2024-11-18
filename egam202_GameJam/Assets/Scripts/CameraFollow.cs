using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;          // 플레이어의 Transform
    public float distance = 10f;      // 카메라와 플레이어 간의 거리
    public float height = 5f;         // 카메라의 높이 (y축)
    public float damping = 5f;        // 부드러운 이동 속도

    private Vector3 offset;           // 초기 오프셋 값

    // 중력 상태에 따른 카메라 각도 설정
    public float cameraAngle = 15f;  // 기본 카메라 각도
    public float cameraHorizontalAngle = 0f;
    public float angleAdjustmentSpeed = 2f; // 카메라 각도 변경 속도

    // Update로 중력에 따른 카메라 각도 변경을 다룰 경우 
    public Inventory WhenWallis; // 예시로 사용하는 중력 상태 변수

    private void Start()
    {
        // 초기 카메라 위치를 기준으로 오프셋 계산
        offset = new Vector3(0, height, -distance);
    }

    private void LateUpdate()
    {
        // 중력 상태에 따라 카메라 각도 조정
        AdjustCameraAngle();

        // 목표 위치 계산 (플레이어 위치 + 오프셋)
        Vector3 targetPosition = player.position + offset;

        // 카메라를 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * damping);

        // 카메라는 항상 플레이어를 바라보도록 설정
        transform.LookAt(player.position + Vector3.up * height); // 플레이어의 위쪽을 살짝 바라봄
    }

    private void AdjustCameraAngle()
    {
        cameraAngle = Mathf.Lerp(cameraAngle, 15f, Time.deltaTime * angleAdjustmentSpeed);
        // 중력 상태에 따라 카메라 각도 변경
        if (WhenWallis.Floor)
        {
            cameraHorizontalAngle = Mathf.Lerp(cameraHorizontalAngle, 0f, Time.deltaTime * angleAdjustmentSpeed);
        }
        else if (WhenWallis.Left)
        {
            cameraHorizontalAngle = Mathf.Lerp(cameraHorizontalAngle, -30f, Time.deltaTime * angleAdjustmentSpeed);
        }
        else if (WhenWallis.Right)
        {
            cameraHorizontalAngle = Mathf.Lerp(cameraHorizontalAngle, 30f, Time.deltaTime * angleAdjustmentSpeed);
        }

        // 각도에 따른 오프셋 계산
        offset = new Vector3(0, height, -distance);
        offset = Quaternion.Euler(cameraAngle, cameraHorizontalAngle, 0) * offset; // 카메라 각도에 따라 오프셋 회전
    }
}
