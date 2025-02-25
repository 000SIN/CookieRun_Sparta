using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public enum UIState
{
    Start,
    Score,
    Ingame
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

    //StartUI homeUI = null;

    //ScoreUI scoreUI = null;

    InGameUI ingameUI = null;

    private void Awake()
    {
        instance = this;

        //startUI = GetComponentInChildren<StartUI>(true);
        //StartUI?.Init(this);

        //scoreUI = GetComponentInChildren<ScoreUI>(true);
        //scoreUI?.Init(this);

        ingameUI = GetComponentInChildren<InGameUI>(true);
        ingameUI?.Init(this);

        ChangeState(UIState.Ingame);
    }


    public void ChangeState(UIState state)
    {
        currentState = state;
        //StartUI?.SetActive(currentState);
        //scoreUI?.SetActive(currentState);
        ingameUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        //ChangeState(UIState.Game);
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }
}
