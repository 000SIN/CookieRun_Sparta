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
        GameObject cookie = new();
        try//�ʿ� ������ ��Ű�� ������ �װ� ������
        {
            cookie = FindObjectOfType<Cookie>().gameObject;
            _target = cookie.GetComponent<Transform>();
        }
        catch//�ʿ� ������ ��Ű�� ������ ���� ������
        {
            if (_target == null)
            {
                cookie = Instantiate(GameManager.Instance.cookiePrefab);
                _target = cookie.transform;
                
            }
        }
        finally
        {
            UIManager.Instance.cookie = cookie.GetComponent<Cookie>();

            // ������ ����(ī�޶� ��ġ�� ��Ű�� ��ġ�� ��)
            offsetX = transform.position.x - _target.position.x;
        }
    }

    void Update()
    {
        if (_target == null) return;

        // ī�޶� ��ġ
        Vector3 pos = transform.position;

        // ī�޶� ��ġ ����
        pos.x = _target.position.x + offsetX;
        transform.position = pos;
    }
}
