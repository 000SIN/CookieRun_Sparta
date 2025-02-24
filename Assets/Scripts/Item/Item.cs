using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // player ��� ��ŰŬ������ ���
    public Cookie cookie;

    // ���� �ӽ�, ���߿� �ٸ��� �� ��� �����ϰ� �� �Է��ϱ�
    public int value = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //player = collision.GetComponent<Cookie>();
        if (cookie != null)
        {
            ApplyEffect(cookie);
            Destroy(gameObject);
        }
    }

/// <summary>
/// ������ ȿ��
/// </summary>
/// <param name="cookie"></param>
    public virtual void ApplyEffect(Cookie cookie)
    {

    }
}


