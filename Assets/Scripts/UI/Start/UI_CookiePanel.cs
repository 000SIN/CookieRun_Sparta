using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CookiePanel : MonoBehaviour
{
    public GameObject cookiePrefab;
    Button cookieButton;

    public Image cookieImage;
    public TextMeshProUGUI cookieName;

    private void Start()
    {
        cookieButton = GetComponent<Button>();
        cookieButton.onClick.AddListener(PassCookie);

        cookieImage.sprite = cookiePrefab.GetComponent<Cookie>().cookieSprite;
        cookieName.text = cookiePrefab.GetComponent<Cookie>().cookieName;
    }

    void PassCookie()//쿠키 선택하면 게임매니저에 알려줌
    {
        GameManager.Instance.SetCookie(cookiePrefab);
    }
}
