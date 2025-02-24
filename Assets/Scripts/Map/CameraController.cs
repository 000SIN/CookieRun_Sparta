using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ī�޶� ���� ���
public class CameraController : MonoBehaviour
{
    // Ÿ�� ���� (��Ű)
    public Transform target;
    
    // ������
    float offsetX;

    void Start()
    {
        if (target == null) return;

        // ������ ����(ī���� ��ġ�� ��Ű�� ��ġ�� ��)
        offsetX = transform.position.x - target.position.x;
    }

    void Update()
    {
        if (target == null) return;

        // ī�޶� ��ġ
        Vector3 pos = transform.position;

        // ī�޶� ��ġ ����
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }
}
