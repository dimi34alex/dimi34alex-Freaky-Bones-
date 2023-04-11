using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HandMove : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;
    Camera cam;
    Collider planecollider;
    RaycastHit hit;
    Ray ray;
    private Animator anim;
    public AudioClip[] footsteps;
    AudioSource playeraudio;



    Vector3 newDirection;

    private Animator HandAnim;


    public GameObject Hand;

    public GameObject Camera1;


    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();

        HandAnim = Hand.GetComponent<Animator>();;

        playeraudio = GetComponent<AudioSource>();

    }


    void FixedUpdate()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Input.GetMouseButton(0) && Camera1.GetComponent<CameraTeleport>().SwitchView == false)
        {         
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit,500, whatCanBeClickedOn))
            {

                newDirection = Vector3.RotateTowards(transform.forward, new Vector3(hit.point.x - transform.position.x,0f,hit.point.z - transform.position.z),0.15f,5);
                transform.rotation = Quaternion.LookRotation(newDirection);

                transform.position = Vector3.MoveTowards(transform.position, hit.point,Time.fixedDeltaTime*3);
                HandAnim.SetBool("IsRunning", true);      
            }
        }
        else
        {
                HandAnim.SetBool("IsRunning", false);

        }   
    
    }
}
