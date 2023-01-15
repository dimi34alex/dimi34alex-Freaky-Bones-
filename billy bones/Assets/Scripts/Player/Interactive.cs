using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Interact()
    {
        if(Physics.Raycast(_ray, out _hit,_maxDistanceRay,interactivable))
        {
            if(_hit.transform != null && _hit.transform.GetComponent<richagManager1>() && (_hit.transform.GetComponent<Things_Trigger>().CanUse1 == true || _hit.transform.GetComponent<Things_Trigger>().CanUse2 == true))
            {
                Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    _hit.transform.GetComponent<richagManager1>().Open();
                }
            }
        }
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
    GameObject current_Item;
    bool canPickUp;
    public LayerMask item;

    void Pick_Item()
    {
        if(Physics.Raycast(_ray, out _hit,_maxDistanceRay,item))
        {
            if(_hit.transform.tag == "ThingToPick" && _hit.transform.GetComponent<Things_Trigger>().CanUse1 == true)
            {
                if(canPickUp) Drop();
                current_Item = _hit.transform.gameObject;
                current_Item.GetComponent<Rigidbody>().isKinematic = true;
                current_Item.transform.parent = hand.transform;
                current_Item.transform.localPosition = Vector3.zero;
                current_Item.transform.localEulerAngles = new Vector3(172f,270f,93f);
                canPickUp = true;

                playeraudio.PlayOneShot(sounds[0]);
            }
        }
    }
    void Drop()
    {
        current_Item.transform.parent = null;
        current_Item.GetComponent<Rigidbody>().isKinematic = false;
        canPickUp = false;
        current_Item = null;
    }
}
