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
            outline.GetComponent<Outline>().OutlineWidth = 0;
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
            if((_hit.transform.tag == "Sword" || _hit.transform.tag == "Key" || _hit.transform.tag == "Shvabra" || _hit.transform.tag == "Stone" ) && _hit.transform.GetComponent<Things_Trigger>().CanUse1 == true && GetComponent<CameraTeleport>().SwitchView == true)
            {
                if(_hit.transform.tag == "Sword")
                {
                    if(PlayerCanPick) Drop();
                    player_item = _hit.transform.gameObject;
                    player_item.GetComponent<Rigidbody>().isKinematic = true;
                    player_item.transform.parent = hand.transform;
                    player_item.transform.localPosition = Vector3.zero;
                    player_item.transform.localEulerAngles = new Vector3(172f,270f,93f);
                    PlayerCanPick = true;                    
                }
                else if(_hit.transform.tag == "Key")
                {
                    if(PlayerCanPick) Drop();
                    player_item = _hit.transform.gameObject;
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
                    player_item.GetComponent<Rigidbody>().isKinematic = true;
                    player_item.transform.parent = hand.transform;
                    player_item.transform.localPosition = new Vector3(-0.082f,0.009f,0.029f);
                    player_item.transform.localEulerAngles = new Vector3(172f,270f,93f);
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
            player_item.GetComponent<Rigidbody>().isKinematic = false;
            PlayerCanPick = false;
            player_item = null;            
        }
        if(GetComponent<CameraTeleport>().SwitchView == false)
        {
            hand_item.transform.parent = null;
            hand_item.GetComponent<Rigidbody>().isKinematic = false;
            HandCanPick = false;
            hand_item = null;            
        }
    }
}
