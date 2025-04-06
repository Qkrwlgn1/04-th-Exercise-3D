using System.Collections.Generic;
using UnityEngine;

public class Script1 : MonoBehaviour
{
    string title = "������";
    string playerName = "���˻�";
    int level = 5;
    float strength = 15.5f;
    int exp = 1500;
    int health = 30;
    int mana = 25;
    bool isFullLevel = false;


    void Start()
    {
        Debug.Log("Hello Unity !");

        //1. ����
        

        //2. �׷��� ����
        string[] monsters = { "������", "��ǹ�", "�Ǹ�" };
        int[] monsterLevel = new int[3];
        monsterLevel[0] = 1;
        monsterLevel[1] = 6;
        monsterLevel[2] = 15;

        Debug.Log("�ʿ� �����ϴ� ������ ����");
        Debug.Log(monsterLevel[0]);
        Debug.Log(monsterLevel[1]);
        Debug.Log(monsterLevel[2]);

        List<string> items = new List<string>();
        items.Add("��������30");
        items.Add("��������30");

        //3. ������
        exp -= 10;
        level = exp / 300;
        strength = level * 3.1f;

        Debug.Log("����� �� ����ġ��?");
        Debug.Log(exp);
        Debug.Log("����� ������?");
        Debug.Log(level);
        Debug.Log("����� ����?");
        Debug.Log(strength);

        int nextExp = 300 - (exp % 300);

        Debug.Log("������������ ���� ����ġ��?");
        Debug.Log(nextExp);

        Debug.Log("����� �̸���?");
        Debug.Log(title + " " + playerName);

        Debug.Log("���� �����Դϱ�? + isFullLevel");

        bool isEndTutorial = level > 10;
        Debug.Log("Ʃ�丮���� ���� ����Դϱ�?" + isEndTutorial);

        //bool isBadCondition = health <= 50 && mana <= 20;
        bool isBadCondition = health <= 50 || mana <= 20;

        string condition = isBadCondition ? "����" : "����";

        //4. Ű����

        //5. ���ǹ�
        if (condition == "����")
        {
            Debug.Log("�÷��̾� ���°� ���ڴ� �������� ����ϼ���.");
        }
        else
        {
            Debug.Log("�÷��̾� ���°� �����ϴ�.");
        }

        if (isBadCondition && items[0] == "��������30")
        {
            items.RemoveAt(0);
            health += 30;
            Debug.Log("��������30�� ����Ͽ����ϴ�.");
        }
        else if (isBadCondition && items[0] == "��������30")
        {
            items.RemoveAt(0);
            mana += 30;
            Debug.Log("��������30�� ����Ͽ����ϴ�.");
        }

        switch (monsters[1])
        {
            case "������":
            case "�縷��":
                Debug.Log("���� ���Ͱ� ����!");
                break;

            case "�Ǹ�":
                Debug.Log("���� ���Ͱ� ����!");
                break;

            case "��":
                Debug.Log("���� ���Ͱ� ����!");
                break;

            default:
                Debug.Log("???���Ͱ� ����!");
                break;

        }

        //6. �ݺ���
        while (health > 0)
        {
            health--;
            if (health > 0)
                Debug.Log("�� �������� �Ծ����ϴ�." + health);
            else
                Debug.Log("����Ͽ����ϴ�.");

            if (health == 10)
            {
                Debug.Log("�ص����� ����մϴ�.");
                break;
            }
        }
        
        for (int count = 0; count < 10; count ++)
        {
            health++;
            Debug.Log("�ش�� ġ���� ..." + health);
        }

        for (int index = 0; index < monsters.Length; index++)
        {
            Debug.Log("�� ������ �ִ� ���� : " + monsters[index]);
        }

        foreach (string monster in monsters)
        {
            Debug.Log("�� ������ �ִ� ���� : " + monster);
        }

        Heal();

        for (int index=0; index < monsters.Length; index++)
        {
            Debug.Log("����" + monsters[index] + "����" + Battle(monsterLevel[index]));
        }

        //8. Ŭ����
        Player player = new Player();
        player.id = 0;
        player.name = "������";
        player.title = "������";
        player.strength = 2.4f;
        player.weapon = "���� ������";
        Debug.Log(player.Talk());
        Debug.Log(player.HasWeapon());

        player.LevelUp();
        Debug.Log(player.name + "�� ������" + player.level + "�Դϴ�.");
        Debug.Log(player.move());

    }

    //7. �Լ� (method)
    void Heal()
    {
        health += 10;
        Debug.Log("���� �޾ҽ��ϴ�" + health);
    }

    string Battle(int monsterLevel)
    {
        string result;
        if (level >= monsterLevel)
            result = "�̰���ϴ�.";
        else
             result = "�����ϴ�.";

        return result;
    }

}
