using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.WebRequestMethods;

public class MainCameraMovement : MonoBehaviour
{

    public Inventory WhenWallis;

    public Camera MyCamera;   // ī�޶�
    public GameObject Target; // Ÿ�� (���ΰ� ��)

    public float cameraDistance = 10.0f;  // ī�޶�� Ÿ�� ������ �Ÿ�
    public float cameraHeight = 5.0f;     // ī�޶� ����
    public float cameraAngle = 45.0f;    // ī�޶� ���� (���ͺ� ����)

    public float CameraSpeed = 10.0f;    // ī�޶� �̵� �ӵ�
    public float angleAdjustmentSpeed = 2f; // ī�޶� ���� ���� �ӵ�

    Vector3 targetPos;

    void Start()
    {
        // ī�޶� ����
        cameraHeight = 5.0f;
        cameraDistance = 10.0f;
        cameraAngle = 45.0f;
    }

    void FixedUpdate()
    {
        // ī�޶� Ÿ���� �Ѿư��� ����
        // ī�޶�� Ÿ�� ���� ���ʿ� ��ġ�ϵ���
        Vector3 direction = (Target.transform.position - transform.position).normalized;

        // ī�޶��� ��ǥ ��ġ ���
        float horizontalOffset = Mathf.Sin(Mathf.Deg2Rad * cameraAngle) * cameraDistance;
        float verticalOffset = Mathf.Cos(Mathf.Deg2Rad * cameraAngle) * cameraDistance;

        // Ÿ�� ���� ���� ����
        Vector3 targetPosition = Target.transform.position;
        Vector3 cameraPosition = targetPosition - Target.transform.forward * horizontalOffset + Vector3.up * cameraHeight + Target.transform.up * verticalOffset;

        // ī�޶� �̵�
        transform.position = Vector3.Lerp(transform.position, cameraPosition, Time.deltaTime * CameraSpeed);

        // ī�޶�� Ÿ���� �ٶ�
        transform.LookAt(Target.transform.position + Vector3.up * cameraHeight); // Ÿ���� �ٶ󺸵� �������� ��¦ ��

        AdjustCameraAngle();
    }


    void AdjustCameraAngle()
    {
        // �߷� ���¿� ���� ī�޶� ���� ����
        if (WhenWallis.Floor)
        {
            // �ٴڿ� ���� �� ī�޶� ����
            cameraAngle = Mathf.Lerp(cameraAngle, 45f, Time.deltaTime * angleAdjustmentSpeed);  // 45��
        }
        else if (WhenWallis.Left)
        {
            // ���� ���� ���� �� ī�޶� ����
            cameraAngle = Mathf.Lerp(cameraAngle, 90f, Time.deltaTime * angleAdjustmentSpeed);  // 90�� (����� ����)
        }
        else if (WhenWallis.Right)
        {
            // ������ ���� ���� �� ī�޶� ����
            cameraAngle = Mathf.Lerp(cameraAngle, 0f, Time.deltaTime * angleAdjustmentSpeed);  // 0�� (����� ����)
        }
    }
}
