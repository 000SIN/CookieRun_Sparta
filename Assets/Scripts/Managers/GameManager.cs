using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class GameManager : Singleton<GameManager>
{

    public UIManager uiManager;

    //���� �帥 �ð�
    public float timePassed;

    public int totalScore;
    public bool isPlaying;

    private void Update()
    {
        if (!isPlaying) return;
        totalScore++;
        timePassed += Time.deltaTime; //�ð� �ֽ�ȭ

        totalScore = totalScore + 1;
    }

    public void StartGame()//���� ����
    {
        isPlaying = true;
        timePassed = 0;
        totalScore = 0;
        SoundManager.Instance.PlayBGM("Bgm_Map_0");
    }

    public void AddScore(int score)
    {
        totalScore += score;
        AchievementManager.Instance.UpdateAchievement("Score", totalScore);
    }

    public void GameOver()
    {
        isPlaying = false;

        if (PlayerPrefs.GetInt("Map1_HighScore", 0) < totalScore) //�ְ� ���� ��ü.
        {
           PlayerPrefs.SetInt("Map1_HighScore",totalScore);
        }

        uiManager.ChangeState(UIState.Score);
    }
}
