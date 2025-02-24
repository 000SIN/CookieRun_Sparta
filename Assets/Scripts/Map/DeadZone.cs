using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ����
public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� ��ü���� Cookie ������Ʈ ������
        Cookie cookie = collision.GetComponent<Cookie>();

        // null�� �ƴϸ� Dead ����
        if (cookie != null)
        {
            cookie.Hit(1000f);
            // �ӽ÷� �ı� �־��
            Destroy(collision.gameObject);
        }
    }
}
