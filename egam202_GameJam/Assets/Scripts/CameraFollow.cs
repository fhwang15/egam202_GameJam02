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

    private void Start()
    {
        // 초기 카메라 위치를 기준으로 오프셋 계산
        offset = new Vector3(0, height, -distance);
    }

    private void LateUpdate()
    {
        // 목표 위치 계산 (플레이어 위치 + 오프셋)
        Vector3 targetPosition = player.position + offset;

        // 카메라를 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * damping);

        // 카메라가 항상 플레이어를 바라보도록 설정
        transform.LookAt(player.position);
    }
}
