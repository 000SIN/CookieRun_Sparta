using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : Singleton<AchievementManager>
{
    public int totalDodgeObstacle = 100;
    private int currentDodgeObstacle = 0;

    public Text achievementText;

    void Update()
    {
        CheckObstacle();
    }

    void CheckObstacle()
    {
        if (currentDodgeObstacle >= totalDodgeObstacle)
        {
            achievementText.text = "�������� �޼�: ��ֹ� ȸ�� 10��!";
            Debug.Log(achievementText.text);
            // ����
        }
    }

    public void DodgedObstacle()
    {
        currentDodgeObstacle++;

        Debug.Log("���� ȸ�� Ƚ��: " + currentDodgeObstacle);
    }

    public void DodgedReset()
    {
        currentDodgeObstacle = 0;

        Debug.Log("���� ȸ�� Ƚ�� �ʱ�ȭ");
    }
}
