using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.PlayerLoop.EarlyUpdate;

public class ClearZone : MonoBehaviour
{
    public GameObject clearUI;
    private GameObject nextButton;
    private GameObject exitButton;

    private void Start()
    {
        nextButton = clearUI.transform.Find("NextButton").gameObject;
        exitButton = clearUI.transform.Find("ExitButton").gameObject; 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Cookie"))
        {
            GameManager.Instance.ScoreUpdate();
            ShowClearUI();
        }
    }

    void ShowClearUI()
    {
        UIManager.Instance.ChangeState(UIState.Clear); // UI Ȱ��ȭ

        if(GameManager.Instance.stageNumber == 3)
        {
            nextButton.SetActive(false); // Next ��ư �����
        }
        else
        {
            nextButton.SetActive(true); // �ٸ� �������������� Next ��ư ���̱�
        }

        exitButton.SetActive(true);
        GameManager.Instance.isPlaying = false;
    }
}
