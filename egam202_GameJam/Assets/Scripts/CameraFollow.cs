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

    private void Start()
    {
        // �ʱ� ī�޶� ��ġ�� �������� ������ ���
        offset = new Vector3(0, height, -distance);
    }

    private void LateUpdate()
    {
        // ��ǥ ��ġ ��� (�÷��̾� ��ġ + ������)
        Vector3 targetPosition = player.position + offset;

        // ī�޶� �ε巴�� �̵�
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * damping);

        // ī�޶� �׻� �÷��̾ �ٶ󺸵��� ����
        transform.LookAt(player.position);
    }
}
