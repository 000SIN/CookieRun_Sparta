using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ī�޶� ���� ���
public class CameraController : MonoBehaviour
{
    // Ÿ�� ���� (��Ű)
    Transform _target;
    
    // ������
    float offsetX;

    void Start()
    {
        
        if (_target == null) return;

        // ������ ����(ī�޶� ��ġ�� ��Ű�� ��ġ�� ��)
        offsetX = transform.position.x - _target.position.x;
    }

    void Update()
    {

        if (_target == null)
        {
            Cookie cookie = FindObjectOfType<Cookie>();
            if(cookie != null)
            {
                _target = cookie.transform;
            }
            
            return;
        }
        

        // ī�޶� ��ġ
        Vector3 pos = transform.position;

        // ī�޶� ��ġ ����
        pos.x = _target.position.x + offsetX;
        transform.position = pos;
    }
}
