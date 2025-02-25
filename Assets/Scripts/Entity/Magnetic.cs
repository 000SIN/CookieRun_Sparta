using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    public float pullPower = 1f;
    public float detectionRadius = 3f;  // ���� ����
    public bool isMagnetic = true;//�ڼ� ����
    LayerMask targetLayer;  // ������ ���̾�

    Collider2D[] hitColliders;

    private void Start()
    {
        targetLayer = LayerMask.GetMask("Item");
    }

    void Update()
    {
        PullItems();
    }

    public void Init(float pPower, float dRadius)
    {
        pullPower = pPower;
        detectionRadius = dRadius;
    }

    void PullItems()//�ڼ�
    {
        Detect();

        foreach(Collider2D item in hitColliders)
        {
            item.transform.transform.position = Vector2.Lerp(item.transform.position, transform.position, pullPower * Time.deltaTime);
        }
    }

    void Detect()//�ֺ��� �ִ� �ݶ��̴� ����
    {
        hitColliders = Physics2D.OverlapCircleAll(GetCenter(), detectionRadius, targetLayer);
    }

    Vector2 GetCenter()
    {
        return transform.GetComponent<BoxCollider2D>().bounds.center;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(GetCenter(), detectionRadius);
    }

    public void OnMagnetic()
    {
        isMagnetic = true;
    }

    public void OffMagnetic()
    {
        isMagnetic = false;
    }
}
