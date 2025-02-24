using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ü������ ����
/// </summary>
public class Potion : Item
{
    [SerializeField] private int heal; 
    public override void ApplyEffect(Cookie cookie)
    {
        cookie.Heal(heal);
    }
}
