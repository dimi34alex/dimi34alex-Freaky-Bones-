using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichagMain : MonoBehaviour
{
   public GameObject Shvabra;
    public bool CanUse1 = false;
    public bool CanUse2 = false;
    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
           if(Shvabra.GetComponent<Things_Trigger>().CanUse1 == true)
           {
                CanUse1 = true; 
           } 
        }
        if(other.tag == "Hand")
        {
            if(Shvabra.GetComponent<Things_Trigger>().CanUse2 == true)
           {
                CanUse2 = true; 
           } 
        }
    }
    void OnTriggerExit (Collider other)
    {
        if(other.tag == "Player")
        {
           CanUse1 = false; 
        }
        if(other.tag == "Hand")
        {
           CanUse2 = false; 
        }
    }

}
