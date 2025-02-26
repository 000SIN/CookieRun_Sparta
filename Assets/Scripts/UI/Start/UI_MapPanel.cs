using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MapPanel : MonoBehaviour
{
    public string sceneName;

    Button mapButton;

    Image mapImage;
    public Sprite mapSprite;
    public TextMeshProUGUI mapNameText;

    private void Start()
    {
        mapImage = GetComponent<Image>();

        mapButton = GetComponent<Button>();
        mapButton.onClick.AddListener(PassMap);

        mapSprite = mapImage.sprite;
        mapNameText.text = sceneName;
    }

    void PassMap()//�� �����ϸ� ���ӸŴ����� �˷���
    {
        GameManager.Instance.SetMap(this);
    }
}
