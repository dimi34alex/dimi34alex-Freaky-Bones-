using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTeleport : MonoBehaviour
{

    public GameObject CamPosP;
    public GameObject CamPosH;
    public bool SwitchView = true;
    public GameObject Player;
    public GameObject Hand;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchView = !SwitchView;
        }

        if(SwitchView == true)
        {
            transform.position = CamPosP.transform.position;
        }

        if(SwitchView == false)
        {
            transform.position = CamPosH.transform.position;
        }
    }

}
