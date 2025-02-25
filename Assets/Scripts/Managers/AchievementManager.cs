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

    // ���� ��ǥġ
    public int totalCollectJelly = 10;
    // ���� ���� ���� ��
    private int currentCollectJelly = 0;
    // ���� ���� ���� Ŭ���� ����
    private bool CompleteJelly = false;

    // ���� ��ǥġ
    public int totalScore = 100;
    // ���� ����
    private int currentScore = 0;
    // ���� ���� ���� Ŭ���� ����
    private bool CompleteScore = false;

    void CheckObstacle()
    {
        // ȸ�� ���� ���� Ŭ���� ���� üũ
        if (!CompleteObstacle && (currentDodgeObstacle >= totalDodgeObstacle))
        {
            CompleteObstacle = true;
            Debug.Log($"ȸ�� ���� �Ϸ� : {currentDodgeObstacle} ���� ȸ��");
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

    void CheckJelly()
    {
        // ���� ���� ���� Ŭ���� ���� üũ
        if (!CompleteJelly && (currentCollectJelly >= totalCollectJelly))
        {
            CompleteJelly = true;
            Debug.Log($"���� ���� �Ϸ� : {CompleteJelly} �� �Ա�!");
            // ui�� ǥ��, ���� �߰�
        }
    }

    public void CollectedJelly()
    {
        // ���� �Ծ��� ��
        currentCollectJelly++;

        Debug.Log($"���� ���� ���� ���� : {currentCollectJelly}");

        // Ŭ���� ���� üũ
        CheckJelly();
    }

    void CheckScore()
    {
        // ���� ���� ���� Ŭ���� ���� üũ
        if (!CompleteScore && (currentScore >= totalScore))
        {
            CompleteScore = true;
            Debug.Log($"���� ���� �Ϸ� : {currentScore} �� ȹ��");
            // ui�� ǥ��, ���� �߰�
        }
    }

    public void CompareScore(int score)
    {
        // ���� ȹ�� ��
        currentScore = score;

        Debug.Log($"���� ���� : {currentScore}");

        // Ŭ���� ���� üũ
        CheckScore();
    }
}
