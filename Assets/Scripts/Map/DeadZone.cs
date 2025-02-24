using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ����
public class DeadZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� ��ü���� Cookie ������Ʈ ������
        Cookie cookie = collision.gameObject.GetComponent<Cookie>();

        // null�� �ƴϸ� Dead ����
        if (cookie != null)
        {
            cookie.Hit(10f);
            GameManager.Instance.isPlaying = false;
            if(!cookie.isDead) cookie.Rescue();
            //GameManager.Instance.isPlaying = false;
            // �ӽ÷� �ı� �־��
            //Destroy(collision.gameObject);
        }
    }
}
