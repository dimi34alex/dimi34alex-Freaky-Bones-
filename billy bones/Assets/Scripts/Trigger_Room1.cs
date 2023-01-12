using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Room1 : MonoBehaviour
{
    public GameObject potol;
    public bool Player_in_Room = false;
    public bool Hand_in_Room = false;

    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player" || other.tag == "Hand")
        {
            potol.GetComponent<Darkness>().Dark();
        }
    }

    void OnTriggerStay (Collider other)
    {
        if(other.tag == "Player")
        {
            Player_in_Room = true;
        }
        if(other.tag == "Hand")
        {
            Hand_in_Room = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if((other.tag == "Player"))
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
        }
    }
}
