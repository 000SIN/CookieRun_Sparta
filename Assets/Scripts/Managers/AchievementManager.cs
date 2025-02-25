using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ���� ���� �Ŵ���
public class AchievementManager : Singleton<AchievementManager>
{
    public class Achievement
    {
        // ���� ���� �̸�
        public string name;
        // ��ǥ ��
        public int total;
        // ���� ��
        public int current;
        // ���� ���� �޼� ����
        public bool Completed;
        // ��ǥ �޼� ���� (current >= total �̸� true)
        public bool isComplete => current >= total;

        public Achievement(string _name, int _total)
        {
            this.name = _name;
            this.total = _total;
            this.current = 0;
            this.Completed = false;
        }

        public void AddCurrent(int amount = 1)
        {
            // �Ϸ�� �Ÿ� ����
            if (Completed) return;

            // current ����
            current += amount;

            // �޼� ���ΰ� true�϶�
            if (isComplete)
            {
                // ���� ���� �Ϸ�
                Completed = true;
                Debug.Log($"{name} ���� �޼�!");
                // ui ����, ���� �߰�
            }
        }

        public void Reset()
        {
            // �̿Ϸ� �����϶��� �ʱ�ȭ ����
            if (!Completed)
            {
                current = 0;
                Debug.Log($"{name} ���� ���൵ �ʱ�ȭ��!");
            }
        }
    }

    // �񼭳ฮ ��� (Ű Ÿ�� string / ������ Ÿ�� Achievement)
    private Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();

    private void Start()
    {
        // �ʱ�ȭ ����
        achievements["Dodge"] = new Achievement("Dodge", 10);
        achievements["Jelly"] = new Achievement("Jelly", 10);
        achievements["Score"] = new Achievement("Score", 10);
    }

    public void UpdateAchievement(string name, int amount = 1)
    {
        // ���� ���� ���� ���� ������Ʈ, ������ Ű�� �������� AddCurrent
        if (achievements.ContainsKey(name))
        {
            achievements[name].AddCurrent(amount);
        }
    }

    public bool isAchievementComplete(string name)
    {
        // ���� ���� �Ϸ� �Ǿ����� üũ, ������ Ű�� �ִ��� �� �༮�� �Ϸ� �Ǿ����� Ȯ��, ���߿� UI�� ������ �� �� �� ����
        return achievements.ContainsKey(name) && achievements[name].isComplete;
    }

    public void RestDodgeAchievement()
    {
        // �ǰ� �� ȸ�� ���� ���� ����, ������ Ű�� ���� ���� Reset
        if (achievements.ContainsKey("Dodge"))
        {
            achievements["Dodge"].Reset();
        }
    }
}
