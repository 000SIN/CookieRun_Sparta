using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��ֹ� ����
public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� ��ü���� Cookie ������Ʈ ������
        Cookie cookie = collision.GetComponent<Cookie>();

        // null�� �ƴϸ� HIt ����
        if (cookie != null)
        {
            AchievementManager.Instance.RestDodgeAchievement();
            cookie.Hit(10f);
        }
    }
}
