using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Player player;

    // ���� �ӽ�, ���߿� �ٸ��� �� ��� �����ϰ� �� �Է��ϱ�
    public int value = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            ApplyEffect(player);
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// ������ ȿ��
    /// </summary>
    /// <param name="player"></param>
    public virtual void ApplyEffect(Player player)
    {

    }
}


