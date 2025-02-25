using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //게임 흐른 시간
    public float timePassed;

    int totalScore;

    public bool isPlaying;

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (!isPlaying)
        {
            Time.timeScale = 0f;
            return;
        }

        Time.timeScale = 1f;

        timePassed += Time.deltaTime; //시간 최신화
    }

    public void StartGame()//게임 시작
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
}
