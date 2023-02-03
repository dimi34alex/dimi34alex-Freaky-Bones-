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
    public AudioClip[] footsteps;
    AudioSource playeraudio;
    Rigidbody _rb;
    Vector3 directionOfMouve;

    public Transform Player;
    Vector3 newDirection;
    


    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        planecollider = GameObject.Find("Plane").GetComponent<Collider>();
        anim = GetComponent<Animator>();
        playeraudio = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();
        directionOfMouve = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit,500, whatCanBeClickedOn))
        //{
            //transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));     
        //}  


         //transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,5));
        if(Input.GetMouseButton(0))
        {         
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit,500, whatCanBeClickedOn))
            {

                newDirection = Vector3.RotateTowards(transform.forward, hit.point - transform.position,0.1f,10);
                transform.rotation = Quaternion.LookRotation(newDirection);

                transform.position = Vector3.MoveTowards(transform.position, hit.point,Time.fixedDeltaTime*5);
                anim.SetBool("IsRunning", true);       
            }
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }   
    
    }
    void Footstep()
    {
        int randInd = Random.Range(0, footsteps.Length);

        playeraudio.PlayOneShot(footsteps[randInd]);
    }
}
