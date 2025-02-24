using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : Singleton<AchievementManager>
{
    public int totalDodgeObstacle = 3;
    private int currentDodgeObstacle = 0;

    private bool ObstacleAchievement = false;

    void CheckObstacle()
    {
        if (!ObstacleAchievement && (currentDodgeObstacle >= totalDodgeObstacle))
        {
            ObstacleAchievement = true;
            Debug.Log($"ȸ�� ���� �Ϸ� {currentDodgeObstacle} ���� ȸ��");
            // ui�� ǥ��. ���� �߰�
        }
    }

    public void DodgedObstacle()
    {
        currentDodgeObstacle++;

        Debug.Log("���� ȸ�� Ƚ��: " + currentDodgeObstacle);

        CheckObstacle();
    }

    public void DodgedReset()
    {
        currentDodgeObstacle = 0;

        Debug.Log("���� ȸ�� Ƚ�� �ʱ�ȭ");
    }
}
