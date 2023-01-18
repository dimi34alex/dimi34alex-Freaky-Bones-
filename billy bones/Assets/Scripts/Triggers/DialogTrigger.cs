using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public GameObject P1, P2, P3, P4, T1, T2, T3;
    public int x1, x2, count = 0;
    public float time;

    void OnTriggerEnter()
    {
        x1 = Random.Range(1, 5);
        switch(x1)
        {
            case 1:
                P1.SetActive(true);
                P2.SetActive(false);
                P3.SetActive(false);
                P4.SetActive(false);
                break;
            case 2:
                P1.SetActive(false);
                P2.SetActive(true);
                P3.SetActive(false);
                P4.SetActive(false);
                break;
            case 3:
                P1.SetActive(false);
                P2.SetActive(false);
                P3.SetActive(true);
                P4.SetActive(false);
                break;
            case 4:
                P1.SetActive(false);
                P2.SetActive(false);
                P3.SetActive(false);
                P4.SetActive(true);
                break;
            default:
                break;
        }
    }

    void OnTriggerStay()
    {
        if (count == 0)
        {
            x2 = Random.Range(1, 4);
            Invoke("Choice", 4f);
            count = 1;
        }
    }

    void Choice()
    {
        P1.SetActive(false);
        P2.SetActive(false);
        P3.SetActive(false);
        P4.SetActive(false);

        switch (x2)
        {
            case 1:
                T1.SetActive(true);
                Invoke("PanelOff", 15f);
                break;
            case 2:
                T2.SetActive(true);
                Invoke("PanelOff", 10f);
                break;
            case 3:
                T3.SetActive(true);
                Invoke("PanelOff", 14f);
                break;
        }
    }

    void PanelOff()
    {
        T1.SetActive(false);
        T2.SetActive(false);
        T3.SetActive(false);
    }

    void OnTriggerExit()
    {
        x1 = x2 = 0;
        count = 0;
        P1.SetActive(false);
        P2.SetActive(false);
        P3.SetActive(false);
        P4.SetActive(false);
        PanelOff();
    }
}
