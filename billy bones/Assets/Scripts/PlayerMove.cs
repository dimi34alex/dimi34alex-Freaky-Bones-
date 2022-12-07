using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;

    private NavMeshAgent myAgent;

    private Animator anim;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(myRay, out hitInfo,100, whatCanBeClickedOn))
            {
                myAgent.enabled = true;
                myAgent.speed = 5;
                myAgent.acceleration = 1000;
                myAgent.SetDestination(hitInfo.point);
                anim.SetBool("IsRunning", true);
            } 
        }
        else
        {
           myAgent.speed = 0;
           myAgent.enabled = false;
           anim.SetBool("IsRunning", false);
        }
    }
}
