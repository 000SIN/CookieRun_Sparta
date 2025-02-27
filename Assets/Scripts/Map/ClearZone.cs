using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearZone : MonoBehaviour
{
    public GameObject clearUI;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Cookie"))
        {
            ShowClearUI();
        }
    }

    void ShowClearUI()
    {
        clearUI.SetActive(true); // UI Ȱ��ȭ
        Time.timeScale = 0f; // ���� ���� (���� ����)
    }
}
