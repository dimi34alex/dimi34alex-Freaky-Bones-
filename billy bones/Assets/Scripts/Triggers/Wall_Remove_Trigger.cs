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

    }

     void OnTriggerStay(Collider other)
     {
        if(other.tag == "Player")
        {
            if(Camera1.GetComponent<CameraTeleport>().SwitchView == true)
            {
                Deactivate_Walls();
            }
            if(Camera1.GetComponent<CameraTeleport>().SwitchView == false)
            {
                Activate_Walls();
            }
        }

        if(other.tag == "Hand")
        {
            if(Camera1.GetComponent<CameraTeleport>().SwitchView == false)
            {
                Deactivate_Walls();
            }
            if(Camera1.GetComponent<CameraTeleport>().SwitchView == true)
            {
                Activate_Walls();
            }
        }
        else if(other.tag == "Hand" && Camera1.GetComponent<CameraTeleport>().SwitchView == false)
        {
            Deactivate_Walls();
        }

        if (other.tag == "Hand" && Camera1.GetComponent<CameraTeleport>().SwitchView == true)
        {
            Activate_Walls();
        }
        else if (other.tag == "Player" && Camera1.GetComponent<CameraTeleport>().SwitchView == false)
        {
            Activate_Walls();
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
            Activate_Walls();
        }
    }
    void Activate_Walls()
    {
            wall1.SetActive(true);
            WALL1.SetActive(false);
            wall2.SetActive(true);
            WALL2.SetActive(false);
    }
    void Deactivate_Walls()
    {
            wall1.SetActive(false);
            WALL1.SetActive(true);
            wall2.SetActive(false);
            WALL2.SetActive(true);
    }
}
