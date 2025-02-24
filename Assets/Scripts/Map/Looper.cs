using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��� ���� ���±�
public class Looper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� ��ü�� �±װ� Grounds�� ����
        if (collision.CompareTag("Grounds"))
        {
            // �ݶ��̴��� ���� ����
            float width = ((BoxCollider2D)collision).size.x;

            // �浹�� ��ü�� ��ġ
            Vector3 pos = collision.transform.position;

            // ��ü�� x�� width��ŭ �̵�
            pos.x += width;
            collision.transform.position = pos;
            return;
        }
    }
}
