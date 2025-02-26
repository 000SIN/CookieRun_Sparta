using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Processors;

public class GameManager : Singleton<GameManager>
{

    public UIManager uiManager;

    //���� �帥 �ð�
    public float timePassed;

    public int totalScore;
    public bool isPlaying;
    
    // Ʃ�丮�� �� üũ
    public bool isTutorialScene;

    private void Start()
    {
        UpdateTutorialState();
        StartGame();
    }

    private void Update()
    {
        if (!isPlaying) return;

        timePassed += Time.deltaTime; //�ð� �ֽ�ȭ
    }

    private void OnEnable()
    {
        // ������Ʈ�� Ȱ��ȭ �� �� ����Ǵ� �⺻�Լ� > �� ���� �� �޼��带 �������. OnSceneLoaded �ڵ����� ����
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // ������Ʈ�� ��Ȱ��ȭ �� �� ����Ǵ� �⺻�Լ� > ��ϵ� �޼��� ����. ���ʿ��� �̺�Ʈ ȣ�� ����
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // �� ���� �� ���� �Ǵ� �Լ� > Ʃ�丮�� ���� ����
        UpdateTutorialState();
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

    private void UpdateTutorialState()
    {
        // ���� ���� Ʃ�丮���� �ƴϸ� false, ������ true
        isTutorialScene = SceneManager.GetActiveScene().name == "Tutorial";
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
