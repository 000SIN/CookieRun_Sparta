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

    public int totalCoin;

    // Ʃ�丮�� �� üũ
    public bool isTutorialScene;

    private void Start()
    {
        UpdateTutorialState();
    }

    public GameObject cookiePrefab;
    public string sceneName = "Stage_1";
    public Sprite sceneSprite;

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
        isPlaying = true;
    }

    public void StartGame()//���� ����
    {
        SoundManager.Instance.StopBGM();
        isPlaying = true;
        timePassed = 0;
        totalScore = 0;
        SoundManager.Instance.PlayBGM($"Bgm_Map_{sceneName.Split('_')[1]}");
    }

    public void AddScore(int score)
    {
        totalScore += score;
        AchievementManager.Instance.UpdateAchievement("Score", totalScore);
    }

    public void AddCoin(int coin)
    {
        totalCoin += coin;
        PlayerPrefs.SetInt("TotalCoin", totalCoin);
        PlayerPrefs.Save();
        Debug.Log($"���� {totalCoin} ����");
    }

    private void UpdateTutorialState()
    {
        // ���� ���� Ʃ�丮���� �ƴϸ� false, ������ true
        isTutorialScene = SceneManager.GetActiveScene().name == "Tutorial";
    }

    public void GameOver()
    {
        isPlaying = false;

        if (PlayerPrefs.GetInt($"Map_{GameManager.Instance.sceneName.Split('_')[1]}_HighScore", 0) < totalScore) //�ְ� ���� ��ü.
        {
           PlayerPrefs.SetInt($"Map_{GameManager.Instance.sceneName.Split('_')[1]}_HighScore",totalScore);
        }

        uiManager.ChangeState(UIState.Score);

        SoundManager.Instance.StopBGM();
    }

    public void SetCookie(GameObject cookie)
    {
        cookiePrefab = cookie;
    }

    public void SetMap(UI_MapPanel map)
    {
        sceneName = map.sceneName;
        sceneSprite = map.mapSprite;
    }
}
