using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;

    private NavMeshAgent myAgent;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(myRay, out hitInfo,100, whatCanBeClickedOn))
            {
                myAgent.speed = 10;
                myAgent.SetDestination(hitInfo.point);
            } 
        }
        else
        {
           myAgent.speed = 0;
        }
    }
}