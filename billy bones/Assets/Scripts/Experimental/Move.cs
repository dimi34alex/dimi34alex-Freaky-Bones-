using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;
    Camera cam;
    Collider planecollider;
    RaycastHit hit;
    Ray ray;
    private Animator anim;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        planecollider = GameObject.Find("Plane").GetComponent<Collider>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider == planecollider)
            {
                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));     
            }  
        }


         //transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,5));
         if(Input.GetMouseButton(0))
         {         
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit,500, whatCanBeClickedOn))
            {
                if(hit.collider == planecollider)
                {
                    transform.position = Vector3.MoveTowards(transform.position, hit.point,Time.deltaTime*5);
                    anim.SetBool("isRunning", true);
                }        
            }
            else
            {
                anim.SetBool("IsRunning", false);
            }   
         }
    }
}