using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf_Killing : MonoBehaviour
{
    public GameObject PlayerDeathControll;
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "RealPlayer")
        {
            PlayerDeathControll.GetComponent<PlayerDead>().Dead = true;
        }
        if(other.tag == "Enemy")
        {
            GameObject enteredObject = other.gameObject;
            enteredObject.gameObject.GetComponent<EnemyDeath>().dead = true;
        }
    }
}
