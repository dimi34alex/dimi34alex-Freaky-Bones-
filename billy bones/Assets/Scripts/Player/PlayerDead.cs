using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public GameObject Skeleton;
 
    public bool Dead = false;

    public GameObject Head;
    public GameObject Body;
    public GameObject LHand;
    public GameObject RHand;
    public GameObject Legs;

    void Update()
    {
        if(Dead == true)
        {
            Skeleton.SetActive(false);

            Head.transform.parent = null;
            Head.GetComponent<Rigidbody>().isKinematic = false;
            Head.GetComponent<Collider>().enabled = true;
            Head.SetActive(true);

            Body.transform.parent = null;
            Body.GetComponent<Rigidbody>().isKinematic = false;
            Body.GetComponent<Collider>().enabled = true;
            Body.SetActive(true);

            LHand.transform.parent = null;
            LHand.GetComponent<Rigidbody>().isKinematic = false;
            LHand.GetComponent<Collider>().enabled = true;
            LHand.GetComponent<Animator>().enabled = false;
            LHand.SetActive(true);

            RHand.transform.parent = null;
            RHand.GetComponent<Rigidbody>().isKinematic = false;
            RHand.GetComponent<Collider>().enabled = true;
            RHand.GetComponent<Animator>().enabled = false;
            RHand.SetActive(true);

            Legs.transform.parent = null;
            Legs.GetComponent<Rigidbody>().isKinematic = false;
            Legs.GetComponent<Collider>().enabled = true;
            Legs.SetActive(true);

            
        }
    }
}
