using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Roll_Control : MonoBehaviour
{
    Animator anim;


    Collider MainCollider;

    void Start()
    {
        anim = GetComponent<Animator>();

    }


    void Update()
    {
        

        if(GetComponent<Things_Trigger>().thrown == true)
        {
            anim.enabled = true;
        }
        else
        {
            anim.enabled = false;
        }
    }
}
