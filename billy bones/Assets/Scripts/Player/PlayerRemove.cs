using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerRemove : MonoBehaviour
{
    public GameObject PlayerYesHand;
    public GameObject PlayerNoHand;
    public bool HasHand = true;

    public GameObject RealHand;
    public GameObject LeftHand;
    public GameObject SpawnPoint;
    private Animator anim;

    void Start()
    {
        anim = RealHand.GetComponent<Animator>();
        PlayerNoHand.GetComponent<PlayerMove>().enabled = false;
        PlayerNoHand.GetComponent<NavMeshAgent>().enabled = false;
        PlayerNoHand.SetActive(false);

        PlayerYesHand.GetComponent<PlayerMove>().enabled = true;
        PlayerYesHand.GetComponent<NavMeshAgent>().enabled = true;
        PlayerYesHand.SetActive(true);        
    }

    void Update()
    {
        if(HasHand == true)
        {
            PlayerNoHand.transform.position = new Vector3(PlayerYesHand.transform.position.x, PlayerYesHand.transform.position.y - 0.005525f,PlayerYesHand.transform.position.z);
            PlayerNoHand.transform.rotation = PlayerYesHand.transform.rotation;
        }
        else
        {
            PlayerYesHand.transform.position = new Vector3(PlayerNoHand.transform.position.x, PlayerNoHand.transform.position.y + 0.005525f,PlayerNoHand.transform.position.z);
            PlayerYesHand.transform.rotation = PlayerNoHand.transform.rotation;
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            HasHand = !HasHand;
            if(HasHand == true)
            {
                PlayerNoHand.GetComponent<PlayerMove>().enabled = false;
                PlayerNoHand.GetComponent<NavMeshAgent>().enabled = false;
                PlayerNoHand.SetActive(false);

                PlayerYesHand.GetComponent<PlayerMove>().enabled = true;
                PlayerYesHand.GetComponent<NavMeshAgent>().enabled = true;
                PlayerYesHand.SetActive(true);

            }
            else
            {
                PlayerYesHand.GetComponent<PlayerMove>().enabled = false;
                PlayerYesHand.GetComponent<NavMeshAgent>().enabled = false;
                PlayerYesHand.SetActive(false);

                PlayerNoHand.GetComponent<PlayerMove>().enabled = true;
                PlayerNoHand.GetComponent<NavMeshAgent>().enabled = true;
                PlayerNoHand.SetActive(true);

                LeftHand.transform.parent = SpawnPoint.transform;
                LeftHand.transform.localPosition = Vector3.zero;
                LeftHand.transform.localEulerAngles = new Vector3(0f,0f,0f);
                LeftHand.transform.parent = null;
                anim.SetTrigger("Fail");
            }
        
        }
    }
}
