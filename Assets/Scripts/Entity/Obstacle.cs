using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public void OnTriggerExit2D(Collider2D collision)
    {
        Cookie cookie = collision.GetComponent<Cookie>();

        if (cookie != null)
        {
            //��Ű ü�� ���� & �ᰣ ����
        }
    }
}
