using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WayPoint : MonoBehaviour
{
    public Camera mainCamera;         // ī�޶� ����
    public Transform target;          // ��ǥ ���� (WayPoint)
    public Image markerImage;         // UI ��Ŀ �̹���

    private RectTransform canvasRect; // ĵ���� RectTransform

    private void Start()
    {
        // ĵ���� RectTransform ĳ��
        canvasRect = markerImage.canvas.GetComponent<RectTransform>();
    }

    private void Update()
    {
        // ���� ��ǥ�� ȭ�� ��ǥ�� ��ȯ
        Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position);

        // ȭ�� �ȿ� ���� ��
        if (screenPos.z > 0 && screenPos.x >= 0 && screenPos.x <= Screen.width && screenPos.y >= 0 && screenPos.y <= Screen.height)
        {
            markerImage.gameObject.SetActive(true); // ��Ŀ Ȱ��ȭ
            markerImage.rectTransform.position = screenPos; // ��Ŀ�� Ÿ�� ��ġ�� �̵�
        }
        else
        {
            // ȭ�� ������ ������ ��
            markerImage.gameObject.SetActive(true);

            // ȭ�� �����ڸ��� ��ġ ����
            Vector3 clampedPos = ClampToScreenEdges(screenPos);
            markerImage.rectTransform.position = clampedPos;
        }
    }

    private Vector3 ClampToScreenEdges(Vector3 screenPos)
    {
        // ȭ���� �����ڸ��� ��ġ ����
        float x = Mathf.Clamp(screenPos.x, 0, Screen.width);
        float y = Mathf.Clamp(screenPos.y, 0, Screen.height);

        return new Vector3(x, y, 0);
    }
}
