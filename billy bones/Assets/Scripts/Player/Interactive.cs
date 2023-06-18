using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interactive : MonoBehaviour

{
    public AudioSource playeraudio;
    public AudioClip[] sounds;

    [SerializeField] private Camera _fpcCamera;
    private Ray _ray;
    private RaycastHit _hit;

    [SerializeField] private float _maxDistanceRay;


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
        BodyAnim = Body.GetComponent<Animator>();
        HeadAnim = Head.GetComponent<Animator>();
        LeftHandAnim = LeftHand.GetComponent<Animator>();
        RightHandAnim = RightHand.GetComponent<Animator>();
    }

    void Update()
    {
        Ray();
        DrawRay();
        Interact();
        OutLining();
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pick_Item();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
            playeraudio.PlayOneShot(sounds[1]);
        }
        if (Input.GetMouseButton(1))
        {
            Zamah();
            
        }
        else if(Input.GetMouseButton(1) == false)
        {
            ChangeAngle = 30;
            Trajectory.gameObject.SetActive(false);

            BodyAnim.SetBool("ZamahTime", false);
            HeadAnim.SetBool("ZamahTime", false);
            LeftHandAnim.SetBool("ZamahTime", false);
            RightHandAnim.SetBool("ZamahTime", false);

            Player1.GetComponent<Move>().enabled = true;
        }
    }

    private void Ray()
    {
        _ray = _fpcCamera.ScreenPointToRay(Input.mousePosition);
    }

    private void DrawRay()
    {
        if(Physics.Raycast(_ray, out _hit,_maxDistanceRay))
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.blue);
        }
    }


    public GameObject Shvabra;
    public GameObject SBpoint;
    private void Interact()
    {
        if(Physics.Raycast(_ray, out _hit,_maxDistanceRay,interactivable))
        {
            if(_hit.transform != null && _hit.transform.GetComponent<richagManager1>() && _hit.transform.GetComponent<Things_Trigger>())
            {
                if(_hit.transform.GetComponent<Things_Trigger>().CanUse1 == true || _hit.transform.GetComponent<Things_Trigger>().CanUse2 == true)
                {
                    Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        _hit.transform.GetComponent<richagManager1>().Open();
                    }
                }
            }

            if(_hit.transform != null && _hit.transform.GetComponent<doorManager>() && _hit.transform.GetComponent<DoorRoom1>())
            {
                if(_hit.transform.GetComponent<DoorRoom1>().CanUse1 == true || _hit.transform.GetComponent<DoorRoom1>().CanUse2 == true)
                {
                    Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        _hit.transform.GetComponent<doorManager>().Open();
                    }
                }
            }

            if(_hit.transform != null && _hit.transform.GetComponent<richagManager1>() && _hit.transform.GetComponent<RichagMain>())
            {
                if(_hit.transform.GetComponent<RichagMain>().CanUse1 == true || _hit.transform.GetComponent<RichagMain>().CanUse2 == true)
                {
                    Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        Drop();
                        Shvabra.GetComponent<Outline>().enabled = false;
                        Shvabra.transform.parent = null;
                        Shvabra.GetComponent<Rigidbody>().isKinematic = true;
                        Shvabra.transform.parent = SBpoint.transform;
                        Shvabra.transform.localPosition = new Vector3(0.0424f,0.0016f,0f);
                        Shvabra.transform.localEulerAngles = new Vector3(0f,0f,90.834f);                            
                        _hit.transform.GetComponent<richagManager1>().Open();
                    }
                }
            }
            if(_hit.transform != null && _hit.transform.tag == "EXIT" && _hit.transform.GetComponent<Things_Trigger>().CanUse1)
            {
                if(_hit.transform.GetComponent<Things_Trigger>().CanUse1 == true)
                {

                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        Died.SetActive(true);
                        Invoke("StartMenu_Loading", 3f);
                    }
                }
            }
        }
    }

    public GameObject Died;

    private void StartMenu_Loading()
    {
        SceneManager.LoadScene("StartMenu");
        Died.SetActive(false);
    }


    private Outline outline;
    public LayerMask interactivable;

    private void OutLining()
    {
        if(Physics.Raycast(_ray, out _hit,_maxDistanceRay,item) || Physics.Raycast(_ray, out _hit,_maxDistanceRay,interactivable))
        {
            outline = _hit.transform.GetComponent<Outline>();
            outline.GetComponent<Outline>().OutlineWidth = 4;
        }
        else
        {
            if (outline != null)
            {
                outline.GetComponent<Outline>().OutlineWidth = 0;
            }
        }
    }


    public GameObject hand;
    public GameObject hand2;
    GameObject player_item;
    GameObject hand_item;
    bool PlayerCanPick;
    bool HandCanPick;
    public LayerMask item;
    void Pick_Item()
    {
        if(Physics.Raycast(_ray, out _hit,_maxDistanceRay,item))
        {
            if((_hit.transform.tag == "Sword" || _hit.transform.tag == "Key" || _hit.transform.tag == "Shvabra" || _hit.transform.tag == "Stone" ) && _hit.transform.GetComponent<Things_Trigger>().CanUse1 == true) //&& GetComponent<CameraTeleport>().SwitchView == true)
            {
                Debug.Log("О ВИЖУ ЕГО");
                if(_hit.transform.tag == "Sword")
                {
                    if(PlayerCanPick) Drop();
                    player_item = _hit.transform.gameObject;
                    player_item.GetComponent<Collider>().enabled = false;
                    player_item.GetComponent<Rigidbody>().isKinematic = true; //родак
                    player_item.transform.parent = hand.transform; //родак
                    player_item.transform.localPosition = Vector3.zero;
                    player_item.transform.localEulerAngles = new Vector3(172f,270f,93f);
                    PlayerCanPick = true;                    
                }
                else if(_hit.transform.tag == "Key")
                {
                    if(PlayerCanPick) Drop();
                    player_item = _hit.transform.gameObject;
                    player_item.GetComponent<Collider>().enabled = false;
                    player_item.GetComponent<Rigidbody>().isKinematic = true;
                    player_item.transform.parent = hand.transform;
                    player_item.transform.localPosition = Vector3.zero;
                    player_item.transform.localEulerAngles = new Vector3(-90f,0f,-90f);
                    PlayerCanPick = true;                    
                }
                else if (_hit.transform.tag == "Shvabra")
                {
                    if(PlayerCanPick) Drop();
                    player_item = _hit.transform.gameObject;

                    foreach (Collider c in player_item.GetComponents<Collider> ())
                    {
                        c.enabled = false;
                    }

                    player_item.GetComponent<Rigidbody>().isKinematic = true;
                    player_item.transform.parent = hand.transform;
                    player_item.transform.localPosition = Vector3.zero;
                    player_item.transform.localEulerAngles = new Vector3(172f,270f,93f);
                    PlayerCanPick = true;
                }
                else if(_hit.transform.tag == "Stone")
                {
                    if(PlayerCanPick) Drop();
                    player_item = _hit.transform.gameObject;
                    player_item.GetComponent<Collider>().enabled = false;
                    player_item.GetComponent<Rigidbody>().isKinematic = true;
                    player_item.GetComponent<Collider>().enabled = false;
                    player_item.transform.parent = hand.transform;
                    player_item.transform.localPosition = new Vector3(0f,0f,0f);
                    player_item.transform.localEulerAngles = new Vector3(0f,0f,0f);
                    PlayerCanPick = true;                    
                }


                playeraudio.PlayOneShot(sounds[0]);
            }
            if((_hit.transform.tag == "Key" || _hit.transform.tag == "Shvabra" ) && _hit.transform.GetComponent<Things_Trigger>().CanUse2 == true && GetComponent<CameraTeleport>().SwitchView == false)
            {
                if(_hit.transform.tag == "Key")
                {
                    if(HandCanPick) Drop();
                    hand_item = _hit.transform.gameObject;
                    hand_item.GetComponent<Collider>().enabled = false;
                    hand_item.GetComponent<Rigidbody>().isKinematic = true;
                    hand_item.transform.parent = hand2.transform;
                    hand_item.transform.localPosition = new Vector3(-0.09f,0.03f,-0.01f);
                    hand_item.transform.localEulerAngles = new Vector3(172f,270f,93f);
                    HandCanPick = true;                    
                }
                else if(_hit.transform.tag == "Shvabra")
                {
                    if(HandCanPick) Drop();
                    hand_item = _hit.transform.gameObject;
                    foreach (Collider c in hand_item.GetComponents<Collider> ())
                    {
                        c.enabled = false;
                    }
                    hand_item.GetComponent<Rigidbody>().isKinematic = true;
                    hand_item.transform.parent = hand2.transform;
                    hand_item.transform.localPosition = new Vector3(0f,0.105f,0.008f);
                    hand_item.transform.localEulerAngles = new Vector3(172f,270f,93f);
                    HandCanPick = true;                     
                }



                playeraudio.PlayOneShot(sounds[0]);
            }
        }
    }
    void Drop()
    {
        if(GetComponent<CameraTeleport>().SwitchView == true)
        {
            player_item.transform.parent = null;
            foreach (Collider c in player_item.GetComponents<Collider>())
            {
                c.enabled = true;
            }
            player_item.GetComponent<Rigidbody>().isKinematic = false;
            PlayerCanPick = false;
            player_item = null;            
        }
        if(GetComponent<CameraTeleport>().SwitchView == false)
        {
            hand_item.transform.parent = null;
            foreach (Collider c in hand_item.GetComponents<Collider>())
            {
                c.enabled = true;
            }
            hand_item.GetComponent<Rigidbody>().isKinematic = false;
            HandCanPick = false;
            hand_item = null;            
        }
    }


    public float AngleInDegrees;
    float g = Physics.gravity.y;
    public GameObject Player1;
    public Transform Target;
    public LayerMask whatCanBeClickedOn;
    public LayerMask whereCanBeThrown;
    public GameObject Bullet;
    Vector3 newDirection;


    public float ChangeAngle = 30;

    public TrajectoryRenderer Trajectory;
    void Zamah()
    {
        if(player_item != null)
        {
            Trajectory.gameObject.SetActive(true);

            BodyAnim.SetBool("Throws",false);
            HeadAnim.SetBool("Throws",false);
            LeftHandAnim.SetBool("Throws",false);
            RightHandAnim.SetBool("Throws",false);

            Player1.GetComponent<Move>().enabled = false;
            if (Physics.Raycast(_ray, out _hit,500, whereCanBeThrown))
            {
                newDirection = Vector3.RotateTowards(Player1.transform.forward, new Vector3(_hit.point.x - Player1.transform.position.x,0f,_hit.point.z - Player1.transform.position.z),0.15f,10);
                Player1.transform.rotation = Quaternion.LookRotation(newDirection);

                BodyAnim.SetBool("ZamahTime", true);
                HeadAnim.SetBool("ZamahTime", true);
                LeftHandAnim.SetBool("ZamahTime", true);
                RightHandAnim.SetBool("ZamahTime", true);

                Vector3 fromTo = _hit.point - hand.transform.position;
                hand.transform.rotation = Quaternion.LookRotation(fromTo, Vector3.up);
                AngleInDegrees = (360 - hand.transform.eulerAngles.x)+ChangeAngle;
                Vector3 fromToXZ = new Vector3(fromTo.x,0f,fromTo.z);
                hand.transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);
                hand.transform.eulerAngles = new Vector3(-AngleInDegrees,hand.transform.eulerAngles.y,hand.transform.eulerAngles.z);

                float x = fromToXZ.magnitude;
                float y = fromTo.y;
                float AngleRadians = AngleInDegrees * Mathf.PI / 180;
                float v2 = (g * x * x) / (2 * (y - Mathf.Tan(AngleRadians) * x ) * Mathf.Pow(Mathf.Cos(AngleRadians), 2 ));
                float v = Mathf.Sqrt(Mathf.Abs(v2));

                Vector3 speed = (_hit.point - hand.transform.position)*v;
                Trajectory.ShowTrajectory(hand.transform.position, hand.transform.forward * v); 

                if(Input.GetMouseButton(0))
                {
                    if( ChangeAngle > 5)
                    {
                        ChangeAngle -= 10 * Time.deltaTime;
                    }                         
                }
                if(Input.GetMouseButtonUp(0))
                {
                    ChangeAngle = 30;
                    Trajectory.gameObject.SetActive(false);

                    BodyAnim.SetBool("Throws",true);
                    HeadAnim.SetBool("Throws",true);
                    LeftHandAnim.SetBool("Throws",true);
                    RightHandAnim.SetBool("Throws",true);

                    BodyAnim.SetBool("ZamahTime", false);
                    HeadAnim.SetBool("ZamahTime", false);
                    LeftHandAnim.SetBool("ZamahTime", false);
                    RightHandAnim.SetBool("ZamahTime", false);

                    player_item.transform.parent = null;
                    player_item.GetComponent<Rigidbody>().isKinematic = false;
                    player_item.GetComponent<Collider>().enabled = true;
                    player_item.GetComponent<Rigidbody>().velocity = hand.transform.forward * v;
                    player_item.GetComponent<Things_Trigger>().thrown = true;
                    PlayerCanPick = false;
                    player_item = null;
                }                
            }
        }
    }


    // void Throw()
    // {
    //     if( player_item != null)
    //     {
    //         if (Physics.Raycast(_ray, out _hit,500, whereCanBeThrown))
    //         {
    //             Vector3 fromTo = _hit.point - hand.transform.position;

    //             hand.transform.rotation = Quaternion.LookRotation(fromTo, Vector3.up);
    //             AngleInDegrees = (360 - hand.transform.eulerAngles.x)+25;

    //             Vector3 fromToXZ = new Vector3(fromTo.x,0f,fromTo.z);
                
    //             hand.transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);
                


    //             hand.transform.eulerAngles = new Vector3(-AngleInDegrees,hand.transform.eulerAngles.y,hand.transform.eulerAngles.z);


    //             float x = fromToXZ.magnitude;
    //             float y = fromTo.y;

    //             float AngleRadians = AngleInDegrees * Mathf.PI / 180;

    //             float v2 = (g * x * x) / (2 * (y - Mathf.Tan(AngleRadians) * x ) * Mathf.Pow(Mathf.Cos(AngleRadians), 2 ));

    //             float v = Mathf.Sqrt(Mathf.Abs(v2));


    //             player_item.transform.parent = null;
    //             player_item.GetComponent<Rigidbody>().isKinematic = false;
    //             player_item.GetComponent<Collider>().enabled = true;
    //             player_item.GetComponent<Rigidbody>().velocity = hand.transform.forward * v;
    //             PlayerCanPick = false;
    //             player_item = null;
    //         } 
    //     }     

    // }
}
