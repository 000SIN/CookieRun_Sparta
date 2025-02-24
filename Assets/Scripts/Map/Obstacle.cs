using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Cookie cookie = collision.GetComponent<Cookie>();

        if (cookie != null)
        {
            cookie.Hit(10f);
        }
    }
}
