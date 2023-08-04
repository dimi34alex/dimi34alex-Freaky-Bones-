using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Things_Trigger : MonoBehaviour
{

    public bool CanUse1 = false;
    public bool CanUse2 = false;

    public bool thrown = false;


    void OnCollisionEnter(Collision other)
    {
         if( other.collider.tag == "Enemy" && transform.gameObject.tag == "Sword" && thrown == true)
         {
            other.gameObject.GetComponent<EnemyDeath>().dead = true;
            thrown = false;
         }
         thrown = false;
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
           CanUse1 = true; 
        }
        if(other.tag == "Hand")
        {
           CanUse2 = true; 
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
