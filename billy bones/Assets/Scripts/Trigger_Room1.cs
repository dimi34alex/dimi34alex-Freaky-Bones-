using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Room1 : MonoBehaviour
{
    public GameObject potol;
    public float count = 0;

    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
            potol.GetComponent<Darkness>().Dark();
        }
    }

    void OnTriggerStay (Collider other)
    {
        if(other.tag == "Player")
        {
            count += 1;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if(other.tag == "Player" && count != 0)
        {
            potol.GetComponent<Darkness>().DeDark();
        }
    }
}
