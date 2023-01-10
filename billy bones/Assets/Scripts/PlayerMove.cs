using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;

    private NavMeshAgent myAgent;

    private Animator anim;

    public bool HasTorch = false;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(HasTorch == false)
        {
            anim.SetBool("HasTorch", false);
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
        if(HasTorch == true)
        {
            anim.SetBool("HasTorch", true);
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
                    anim.SetBool("TorchRunning", true);
                } 
            }
            else
            {
                myAgent.speed = 0;
                myAgent.enabled = false;
                anim.SetBool("TorchRunning", false);
            }
        }
    }
}
