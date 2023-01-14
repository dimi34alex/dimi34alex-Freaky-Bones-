using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Room2_out : MonoBehaviour
{
    // �������� ������ �������� :
    // TriggerZone1 - ������� � �������� ���� ������ ��������, ������� � ������
    // Darkness_Room1 - ������ ����, � ����� ����� ����������� ����� ����� ���������� ��� ���� ���� � ����� ��������� ������� ���������
    public GameObject potol1, potol4, potol5, resh; // ��� ������� ������� �����������. �������� ��� � ������� ����
    public bool Player_in_Room = false; // ���������� ��� ������� �� ��������� � ��� �������� � �������� ������������ ���� ���(������� False),
    public bool Hand_in_Room = false; // �� � ���� ����� ���� ������ ��������

    void OnTriggerEnter(Collider other) //������� ���������� ����� ������� other
    {
        if ((other.tag == "Player")) // ���� ��� ������� other ��� Player
        {
            Player_in_Room = true; // ����� � ������� = ������
        }
        if ((other.tag == "Hand")) // ���� ��� ������� other ��� Hand, �.�. ���� ���� ����� � ������� ����
        {
            Hand_in_Room = true; // ���� � ������� ���� = ������
        }
        if (other.tag == "Player" || other.tag == "Hand") // ���� ���� ���-�� �� ���� ��������� ���� � ��������
        {
            potol1.GetComponent<Darkness>().Dark(); // �� ��������� �������� ������������ ������ ������, ����� ��� ������ �������
            potol4.GetComponent<Darkness>().Dark();
            potol5.GetComponent<Darkness>().Dark();
            resh.SetActive(true);
        }
    }
}