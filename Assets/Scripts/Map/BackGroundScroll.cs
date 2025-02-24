using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���, ���� �̵� ȿ��
public class BackGroundScroll : MonoBehaviour
{
    // ī�޶� ��ġ
    public Transform cameraTransform;

    // �ӵ� ( ���, ���� �̵� ȿ�� )
    public float speed = 0.2f;

    // ���� ī�޶� ��ġ
    private Vector3 prevCameraPosition;

    void Start()
    {
        // ���� ī�޶� ��ġ ����
        prevCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        // ������ �ӵ��� ���� ���, ���� �̵�
        Vector3 movement = cameraTransform.position - prevCameraPosition;
        transform.position += movement * speed;
        prevCameraPosition = cameraTransform.position;
    }
}
