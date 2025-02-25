using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum UIState //enum : ���������̸��� ������ ��� ������ ��Ÿ���� �� ����
{
    Start,
    Score,
    InGame,
}

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    UIState currentState = UIState.Start;

    StartUI startUI = null;

    ScoreUI scoreUI = null;

    private void Awake()
    {
        instance = this;

        startUI = GetComponentInChildren<StartUI>(true);
        startUI?.Init(this);

        scoreUI = GetComponentInChildren<ScoreUI>(true);
        scoreUI?.Init(this);

        ChangeState(UIState.Start);
    }


    public void ChangeState(UIState state)
    {
        currentState = state;
        startUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        ChangeState(UIState.InGame);
    }

    public void OnClickExit()
    {
        GameManager.Instance.GameOver();
        ChangeState(UIState.Score);
#if UNITY_EDITOR //����Ƽ �����Ϳ��� ���� �ǰ� ���� �� �� �ֵ���.
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }
}
