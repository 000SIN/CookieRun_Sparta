using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellySpawner : MonoBehaviour
{
    public LineRenderer _lineRenderer;
    public GameObject jellyPrefab;
    [Range(0.1f, 2f)] public float spawnInterval = 0.5f;

    [ContextMenu("Spawn Jellies")]
    void SpawnJellies()
    {
        ClearJellies();

        int vertexCount = _lineRenderer.positionCount;
        Vector3[] pos = new Vector3[vertexCount];//���� ����
        _lineRenderer.GetPositions(pos);
        
        float totalLength = 0f;//�� ����
        for(int i = 0; i < vertexCount - 1; i++)
        {
            totalLength += Vector3.Distance(pos[i], pos[i + 1]);
        }

        float distancefromSpawn = 0f;
        int currentSegment = 0;
        float segmentStartDistance = 0f;

        while (distancefromSpawn <= totalLength)
        {
            float segmentLength = Vector3.Distance(pos[currentSegment], pos[currentSegment + 1]);//���� ������ ����
            float t = (distancefromSpawn - segmentStartDistance) / segmentLength;//���п��� ������ ������ ��ġ�� ����
            t = Mathf.Clamp01(t);//����, ���� ����
            Vector3 spawnPosition = Vector3.Lerp(pos[currentSegment], pos[currentSegment + 1], t);//���п��� ������ ������ ��ġ

            Instantiate(jellyPrefab, spawnPosition, Quaternion.identity, transform);

            distancefromSpawn += spawnInterval;//������ �Ÿ���ŭ �� �Ÿ� ����

            //������ ó������ �ٽ� ���鼭 ���� ������ �� �Ÿ��� ��� ���п� �ִ��� üũ
            while (currentSegment < vertexCount - 1 && (distancefromSpawn - segmentStartDistance) > segmentLength)
            {
                segmentStartDistance += segmentLength;
                currentSegment++;
                if (currentSegment >= vertexCount - 1) break;
                segmentLength = Vector3.Distance(pos[currentSegment], pos[currentSegment + 1]);
            }
        }
    }

    [ContextMenu("Clear Jellies")]
    void ClearJellies()
    {
#if UNITY_EDITOR
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
#endif
    }
}
