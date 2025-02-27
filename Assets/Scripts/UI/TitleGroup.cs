using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleGroup : MonoBehaviour
{
    SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlayBGM("Bgm_Title");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            ChangeScene();
        }
    }
    void ChangeScene()
    {
        PlayerPrefs.DeleteAll();
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.StopAllSound();
            if (!PlayerPrefs.HasKey("FirstPlay"))
            {
                PlayerPrefs.SetInt("FirstPlay", 1);  // ù ���� ����
                PlayerPrefs.Save();  // ���� (�ʼ�)
                SceneManager.LoadScene("Tutorial");  // Ʃ�丮�� ������ �̵�
            }
            else
            {
                SceneManager.LoadScene("Select");  // ����ȭ�� ������ �̵�
            }
        }
    }
}
