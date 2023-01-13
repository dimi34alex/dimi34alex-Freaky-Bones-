using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Remove_Trigger : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject WALL1;
    public GameObject WALL2;
    public GameObject Camera1;
    public bool Player_in_Room = false;
    public bool Hand_in_Room = false;

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
            wall1.SetActive(false);
            WALL1.SetActive(true);
            wall2.SetActive(false);
            WALL2.SetActive(true);
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
            wall1.SetActive(true);
            WALL1.SetActive(false);
            wall2.SetActive(true);
            WALL2.SetActive(false);
        }
    }
}
