using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRemove : MonoBehaviour
{
    public GameObject LeftHand;
    public GameObject RealHand;
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
            LeftHand.transform.parent = SpawnPoint.transform;
            LeftHand.transform.localPosition = Vector3.zero;
            LeftHand.transform.localEulerAngles = new Vector3(0f,0f,0f);
            LeftHand.transform.parent = null;
            anim.SetBool("Failed", true);
        }
    }
}
