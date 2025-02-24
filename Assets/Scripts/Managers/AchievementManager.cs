using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ���� ���� �Ŵ���
public class AchievementManager : Singleton<AchievementManager>
{
    // ȸ�� ��ǥġ
    public int totalDodgeObstacle = 3;
    // ���� ȸ���� ��
    private int currentDodgeObstacle = 0;
    // ȸ�� ���� ���� Ŭ���� ����
    private bool CompleteObstacle = false;

    void CheckObstacle()
    {
        // ȸ�� ���� ���� Ŭ���� ���� üũ
        if (!CompleteObstacle && (currentDodgeObstacle >= totalDodgeObstacle))
        {
            CompleteObstacle = true;
            Debug.Log($"ȸ�� ���� �Ϸ� {currentDodgeObstacle} ���� ȸ��");
            // ui�� ǥ��. ���� �߰�
        }
    }

    public void DodgedObstacle()
    {
        // ȸ�� ���� ��
        currentDodgeObstacle++;

        Debug.Log("���� ȸ�� Ƚ��: " + currentDodgeObstacle);

        // Ŭ���� ���� üũ
        CheckObstacle();
    }

    public void DodgedReset()
    {
        // ȸ�� ���� ��
        currentDodgeObstacle = 0;

        Debug.Log("���� ȸ�� Ƚ�� �ʱ�ȭ");
    }
}
