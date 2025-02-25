using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    // Ʃ�丮�� ui ���� > tutorialzone���� �����ؼ� ���
    public GameObject tutorialUI;
    // ���� �� ���� > �ӽ÷� Stage_1�� �صξ����� ����ȭ�� ���� �ִٸ� �װ� �� ������
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
            // UI Ȱ��ȭ
            ShowTutorial();
        }
    }

    void ShowTutorial()
    {
        // ���� ��� UI�� ��Ȱ��ȭ
        foreach (Transform child in tutorialUI.transform)
        {
            child.gameObject.SetActive(false);
        }

        // ���� number�� �ش��ϴ� UI Ȱ��ȭ
        // transform.childCount > gameobject�� �� ������ �ִ� transform�� �ִ� childCount�� ����ؼ� �ڽ� ��ü�� ���� �� �� ����.
        if (number < tutorialUI.transform.childCount)
        {
            // �ð� ���� �ְ� �; ����ߴµ� �ȸ��缭 �׸Ŵ����� �ڵ� �߰� �ۼ���
            GameManager.Instance.isPlaying = false;

            // ���� UI �� number�� �ش�Ǵ� �༮ Ȱ��ȭ ����
            tutorialUI.transform.GetChild(number).gameObject.SetActive(true);

            // number�� �÷��༭ �ٽ� �޼��� ȣ�� �� ������ UI�� Ȱ��ȭ �ϰ� ����
            number++;
        }
        // UI Ȱ��ȭ ���±� ������ true
        isActive = true;
    }

    private void Update()
    {
        // ����Ű �Է½� �Ѿ
        if (isActive && Input.GetKeyDown(KeyCode.Return))
        {
            // UI�� �������̰ų� �Ѿ����
            if (number >= tutorialUI.transform.childCount)
            {
                // ������ ���� ������ ��ȯ
                LoadNextScene();
                return;
            }
            else
            {
                // �ƴϸ� UI ������
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

        // isPlaying Ȱ��ȭ
        GameManager.Instance.isPlaying = true;

        // isActive�� false�� ���༭ ������ �浹���� �� UI�� ���� �� �ְ� ����
        isActive = false;
    }

    void LoadNextScene()
    {
        // �ش� ���ڿ� Null���� üũ > �ƴϸ� false ��ȯ > ! �� true
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            // ������ ������ ��ȯ, isPlaying Ȱ��ȭ
            SceneManager.LoadScene(nextSceneName);
            GameManager.Instance.isPlaying = true;
        }
    }
}
