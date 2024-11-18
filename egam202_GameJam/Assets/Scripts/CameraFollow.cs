using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;          // �÷��̾��� Transform
    public float distance = 10f;      // ī�޶�� �÷��̾� ���� �Ÿ�
    public float height = 5f;         // ī�޶��� ���� (y��)
    public float damping = 5f;        // �ε巯�� �̵� �ӵ�

    private Vector3 offset;           // �ʱ� ������ ��

    // �߷� ���¿� ���� ī�޶� ���� ����
    public float cameraAngle = 15f;  // �⺻ ī�޶� ����
    public float cameraHorizontalAngle = 0f;
    public float angleAdjustmentSpeed = 2f; // ī�޶� ���� ���� �ӵ�

    // Update�� �߷¿� ���� ī�޶� ���� ������ �ٷ� ��� 
    public Inventory WhenWallis; // ���÷� ����ϴ� �߷� ���� ����

    private void Start()
    {
        // �ʱ� ī�޶� ��ġ�� �������� ������ ���
        offset = new Vector3(0, height, -distance);
    }

    private void LateUpdate()
    {
        // �߷� ���¿� ���� ī�޶� ���� ����
        AdjustCameraAngle();

        // ��ǥ ��ġ ��� (�÷��̾� ��ġ + ������)
        Vector3 targetPosition = player.position + offset;

        // ī�޶� �ε巴�� �̵�
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * damping);

        // ī�޶�� �׻� �÷��̾ �ٶ󺸵��� ����
        transform.LookAt(player.position + Vector3.up * height); // �÷��̾��� ������ ��¦ �ٶ�
    }

    private void AdjustCameraAngle()
    {
        cameraAngle = Mathf.Lerp(cameraAngle, 15f, Time.deltaTime * angleAdjustmentSpeed);
        // �߷� ���¿� ���� ī�޶� ���� ����
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

        // ������ ���� ������ ���
        offset = new Vector3(0, height, -distance);
        offset = Quaternion.Euler(cameraAngle, cameraHorizontalAngle, 0) * offset; // ī�޶� ������ ���� ������ ȸ��
    }
}
