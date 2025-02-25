using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    // Ʃ�丮�� ui ����
    public GameObject tutorialUI;
    // ���� ��
    public string nextSceneName = "Stage_1";
    // ui ��ȣ
    private int number = 0;
    // ui Active ����
    private bool isActive = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��Ű�� �浹�߰�  ui�� ����������
        if (collision != null && collision.CompareTag("Cookie") && !isActive)
        {
            ShowTutorial();
        }
    }

    void ShowTutorial()
    {
        if (number >= tutorialUI.transform.childCount)
        {
            LoadNextScene(); // ������ UI�� �Ѿ�� �� ��ȯ
            return;
        }

        // ��� UI�� ��Ȱ��ȭ
        foreach (Transform child in tutorialUI.transform)
        {
            child.gameObject.SetActive(false);
        }

        // ���� number�� �ش��ϴ� UI Ȱ��ȭ
        if (number < tutorialUI.transform.childCount)
        {
            GameManager.Instance.isPlaying = false;
            tutorialUI.transform.GetChild(number).gameObject.SetActive(true);
            number++;
        }

        isActive = true;
    }

    private void Update()
    {
        // ����Ű �Է½� �Ѿ
        if (isActive && Input.GetKeyDown(KeyCode.Return))
        {
            if (number >= tutorialUI.transform.childCount)
            {
                LoadNextScene(); // ������ UI�� �Ѿ�� �� ��ȯ
                return;
            }
            else
            {
                HideTutorial();
            }
        }
    }

    void HideTutorial()
    {
        // ��� Ʃ�丮�� UI ��Ȱ��ȭ
        foreach (Transform child in tutorialUI.transform)
        {
            child.gameObject.SetActive(false);
        }

        GameManager.Instance.isPlaying = true;

        isActive = false;
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
            GameManager.Instance.isPlaying = true;
        }
    }
}
