using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ھ� ���� ����
/// </summary>
public class Jelly : Item
{
    public override void ApplyEffect(Cookie cookie)
    {
        SoundManager.Instance.PlaySFX("Jelly");
    }
}