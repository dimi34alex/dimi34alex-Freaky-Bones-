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

    private Animator BodyAnim;
    private Animator HeadAnim;
    private Animator LeftHandAnim;
    private Animator RightHandAnim;

    public GameObject Body;
    public GameObject Head;
    public GameObject LeftHand;
    public GameObject RightHand;
    


    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        planecollider = GameObject.Find("Plane").GetComponent<Collider>();

        BodyAnim = Body.GetComponent<Animator>();
        HeadAnim = Head.GetComponent<Animator>();
        LeftHandAnim = LeftHand.GetComponent<Animator>();
        RightHandAnim = RightHand.GetComponent<Animator>();

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

                newDirection = Vector3.RotateTowards(transform.forward, new Vector3(hit.point.x - transform.position.x,0f,hit.point.z - transform.position.z),0.15f,10);
                transform.rotation = Quaternion.LookRotation(newDirection);

                transform.position = Vector3.MoveTowards(transform.position, hit.point,Time.fixedDeltaTime*5);
                BodyAnim.SetBool("IsRunning", true);
                HeadAnim.SetBool("IsRunning", true);
                LeftHandAnim.SetBool("IsRunning", true);
                RightHandAnim.SetBool("IsRunning", true);       
            }
        }
        else
        {
                BodyAnim.SetBool("IsRunning", false);
                HeadAnim.SetBool("IsRunning", false);
                LeftHandAnim.SetBool("IsRunning", false);
                RightHandAnim.SetBool("IsRunning", false);  
        }   
    
    }
    void Footstep()
    {
        int randInd = Random.Range(0, footsteps.Length);

        playeraudio.PlayOneShot(footsteps[randInd]);
    }
}
