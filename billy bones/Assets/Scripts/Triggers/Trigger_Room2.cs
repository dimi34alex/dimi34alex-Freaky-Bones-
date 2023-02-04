using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trigger_Room2 : MonoBehaviour
{
    public GameObject potol1, potol4, potol5, back;
    public TextMeshPro textMeshPro;
    public bool Player_in_Room = false;
    public bool Hand_in_Room = false;

    public void Setup(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
    }

    void OnTriggerEnter (Collider other)
    {
        if((other.tag == "Player"))
        {
            Player_in_Room = true;
        }
        if((other.tag == "Hand"))
        {
            Hand_in_Room = true;
        }
        if(other.tag == "Player" || other.tag == "Hand")
        {
            potol1.GetComponent<Darkness>().Dark();
            potol4.GetComponent<Darkness>().Dark();
            potol5.GetComponent<Darkness>().Dark();
            Setup("R - Drop/Take hand"); ;
            back.SetActive(true);
        }
    }


    void OnTriggerExit (Collider other)
    {
        back.SetActive(false);
        /*if((other.tag == "Player"))
        {
            Player_in_Room = false;
        }
        if((other.tag == "Hand"))
        {
            Hand_in_Room = false;
        }
        if(Player_in_Room == false && Hand_in_Room == false)
        {
            potol.GetComponent<Darkness>().DeDark();
        }*/
    }
}
