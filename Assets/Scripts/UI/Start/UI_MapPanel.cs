using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MapPanel : MonoBehaviour
{
    public string sceneName;

    public Button mapButton;

    public GameObject mapLocked;

    public Image mapImage;
    public Sprite mapSprite;
    public TextMeshProUGUI mapNameText;

    private void Start()
    {
        mapButton.onClick.AddListener(PassMap);

        mapImage.sprite = mapSprite;
        mapNameText.text = sceneName;
    }

    void PassMap()//�� �����ϸ� ���ӸŴ����� �˷���
    {
        GameManager.Instance.SetMap(this);
    }
}
