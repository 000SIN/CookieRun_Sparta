using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// �ν���
/// </summary>
public class Booster : Item
{
    public override void ApplyEffect(Cookie cookie)
    {
        cookie.RunBoost(3f, 10f);
    }
}
 