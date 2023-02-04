using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogTrigger : MonoBehaviour
{
    public GameObject dialog;
    public int x1, x2, count = 0;
    public float time;

    public SpriteRenderer backgroundSprite;
    public TextMeshPro textMeshPro;

    public void Setup(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
    }

    void OnTriggerEnter()
    {
        dialog.SetActive(true);
        x1 = Random.Range(1, 4);
        switch(x1)
        {
            case 1:
                Setup("��, ������! �������!");
                break;
            case 2:
                Setup("�����! ������!");
                break;
            case 3:
                Setup("���� �� ������, ��������!");
                break;
            case 4:
                Setup("�� ��� ���� ���� �����");
                break;
            default:
                break;
        }
    }

    void OnTriggerStay()
    {
        if (count == 0)
        {
            count = 1;
            Invoke("Choice", 3f);
        }
    }

    void Choice()
    {
        x2 = Random.Range(1, 3);
        switch (x2)
        {
            case 1:
                Setup("��, ��� ������� ��� �������, ���� ������ �� �������� � �����������. ����� ���� �� ��� �������� �������� �����. �� ���� �� ������ ������! ������! �� ��������� ������! ����� ��� ������?! ��-��-��!");
                Invoke("PanelOff", 15f);
                break;
            case 2:
                Setup("������, �� ����� ����� � �� �� ���� �������� � ��� ������ � ������� � �����, � ����, ������ ������. � �����, � ��� �������, �� ���� ���� ���������� �����������");
                Invoke("PanelOff", 10f);
                break;
            case 3:
                Setup("������ ����� � ���, ��� ���� �� ������ ���� �� ���� � ����� ������� ����������� �����-������ ������������, � �� �������� �� ��� ��������� �� ������ ����. ������� ��� ��������, ���� ������! �� � ����!");
                Invoke("PanelOff", 14f);
                break;
        }
    }

    void PanelOff()
    {
        dialog.SetActive(false);
    }

    void OnTriggerExit()
    {
        x1 = x2 = 0;
        count = 0;
        dialog.SetActive(false);
/*        PanelOff();*/
    }
}
