using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //���� �帥 �ð�
    public float timePassed;

    private void Update()
    {
        timePassed += Time.deltaTime; //�ð� �ֽ�ȭ
    }

    public void StartGame()//���� ����
    {
        timePassed = 0;
    }
}
