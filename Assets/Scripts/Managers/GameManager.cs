using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //���� �帥 �ð�
    public float timePassed;

    public bool isPlaying;

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (!isPlaying) return;

        timePassed += Time.deltaTime; //�ð� �ֽ�ȭ
    }

    public void StartGame()//���� ����
    {
        isPlaying = true;
        timePassed = 0;
        SoundManager.Instance.PlayBGM("Bgm_Map_0");
    }
}
