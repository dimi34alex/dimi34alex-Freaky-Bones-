using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerRemove : MonoBehaviour
{
    public GameObject Left_Hand_On_The_Skeleton;
    public GameObject PlayerTrigger;
    public bool HasHand = false;


    public GameObject RealHand;
    public GameObject LeftHand;
    public GameObject SpawnPoint;
    private Animator anim;

    void Start()
    {
        anim = RealHand.GetComponent<Animator>();  
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(HasHand == true)
            {
                if(PlayerTrigger.GetComponent<Things_Trigger>().CanUse2 == true)
                {
                    Left_Hand_On_The_Skeleton.SetActive(true);
                    LeftHand.transform.position = transform.position;
                    HasHand = false;
                }
            }
            else
            {
                Left_Hand_On_The_Skeleton.SetActive(false);    

                LeftHand.transform.parent = SpawnPoint.transform;
                LeftHand.transform.localPosition = Vector3.zero;
                LeftHand.transform.localEulerAngles = new Vector3(0f,0f,0f);
                LeftHand.transform.parent = null;
                anim.SetTrigger("Fail");
                HasHand = true;
            }
        
        }
    }
}
