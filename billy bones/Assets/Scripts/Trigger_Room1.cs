using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Room1 : MonoBehaviour
{
    public GameObject potol;
    public bool inRoom = false;

    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
            inRoom = true;
            potol.GetComponent<Darkness>().Dark();
        }
    }

    void OnTriggerStay (Collider other)
    {
        if(other.tag == "Player")
        {
            inRoom = true;
        }
        else
        {
            inRoom = false;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if(other.tag == "Player" && inRoom == false)
        {
            potol.GetComponent<Darkness>().DeDark();
        }
    }
}
