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
        base.ApplyEffect(cookie);
        SoundManager.Instance.PlaySFX("Jelly");
        AchievementManager.Instance.UpdateAchievement("Jelly", 1);
    }
}