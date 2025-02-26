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
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.StopAllSound();
            SceneManager.LoadScene("Stage_1");
        }
        Debug.Log("���� ���� �������� �ʾҽ��ϴ�.");
    }
}
