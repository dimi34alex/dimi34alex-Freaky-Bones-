using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Help_Lvl1 : MonoBehaviour
{
    public GameObject Tips;

    void OnTriggerExit(Collider other)
    {
        Tips.SetActive(false);
    }
}
