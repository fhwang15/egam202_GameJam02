using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayPoint : MonoBehaviour
{
    public Camera mainCamera;         // 카메라 참조
    public Transform target;          // 목표 지점 (WayPoint)
    public Image markerImage;         // UI 마커 이미지

    private RectTransform canvasRect; // 캔버스 RectTransform

    private void Start()
    {
        // 캔버스 RectTransform 캐싱
        canvasRect = markerImage.canvas.GetComponent<RectTransform>();
    }

    private void Update()
    {
        // 월드 좌표를 화면 좌표로 변환
        Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position);

        // 화면 안에 있을 때
        if (screenPos.z > 0 && screenPos.x >= 0 && screenPos.x <= Screen.width && screenPos.y >= 0 && screenPos.y <= Screen.height)
        {
            markerImage.gameObject.SetActive(true); // 마커 활성화
            markerImage.rectTransform.position = screenPos; // 마커를 타겟 위치로 이동
        }
        else
        {
            // 화면 밖으로 나갔을 때
            markerImage.gameObject.SetActive(true);

            // 화면 가장자리에 위치 조정
            Vector3 clampedPos = ClampToScreenEdges(screenPos);
            markerImage.rectTransform.position = clampedPos;
        }
    }

    private Vector3 ClampToScreenEdges(Vector3 screenPos)
    {
        // 화면의 가장자리로 위치 제한
        float x = Mathf.Clamp(screenPos.x, 0, Screen.width);
        float y = Mathf.Clamp(screenPos.y, 0, Screen.height);

        return new Vector3(x, y, 0);
    }
}
