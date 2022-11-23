using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera _fpcCamera;
    private Ray _ray;
    private RaycastHit _hit;

    [SerializeField] private float _maxDistanceRay;

    
    void Update()
    {
        Ray();
        DrawRay();
        Interact();
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

    public GameObject DIMON;
    
    private void Interact()
    {
        if(_hit.transform != null && _hit.transform.GetComponent<Richag1>())
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _maxDistanceRay, Color.green);
            if(Input.GetKeyDown(KeyCode.E))
            {

                _hit.transform.GetComponent<Richag1>().Open();
                DIMON.GetComponent<DemonDoor>().Open();
            }
        }
    }
}
