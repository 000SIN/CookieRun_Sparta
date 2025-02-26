using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //���� �帥 �ð�
    public float timePassed;

    int totalScore;

    public bool isPlaying;

    public GameObject cookiePrefab;
    public string sceneName = "stage_1";

    private void Update()
    {
        if (!isPlaying) return;

        timePassed += Time.deltaTime; //�ð� �ֽ�ȭ
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

    public void SetCookie(GameObject cookie)
    {
        cookiePrefab = cookie;
    }

    public void SetMap(string name)
    {
        sceneName = name;
    }
}
