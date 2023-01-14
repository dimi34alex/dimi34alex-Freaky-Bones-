using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HandCanGoHere : MonoBehaviour
{
    public GameObject Camera1;
    private NavMeshObstacle obstacle;

    void Start()
    {
        obstacle = GetComponent<NavMeshObstacle>();
    }

    void Update()
    {
        if (Camera1.GetComponent<CameraTeleport>().SwitchView == false)
        {
            obstacle.enabled = false;
        }
        else
        {
            obstacle.enabled = true;
        }
    }
}
