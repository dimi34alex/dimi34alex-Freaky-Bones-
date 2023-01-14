using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    public LayerMask whatCanBeClickedOn;
    public float costRunStamina = 0.1f;
    private NavMeshAgent myAgent;
    float timerStaminaRun = 0.0f;
    private Animator anim;
    public GameObject Camera1;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Camera1.GetComponent<CameraTeleport>().SwitchView == true)
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                myAgent.enabled = true;
                myAgent.speed = 5;
                myAgent.acceleration = 1000;
                myAgent.SetDestination(hitInfo.point);
                anim.SetBool("IsRunning", true);
            }
        }
        else if (Input.GetMouseButton(1) && Camera1.GetComponent<CameraTeleport>().SwitchView == true)
        {

            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                if (StaminaBar.instance.staminaBar.value >= 1)
                {
                    if (timerStaminaRun >= costRunStamina)
                    {
                        StaminaBar.instance.UseStamina(1);
                        timerStaminaRun = 0.0f;
                    }
                    myAgent.speed = 10;
                    timerStaminaRun += Time.fixedDeltaTime;
                    myAgent.enabled = true;
                    myAgent.acceleration = 1000;
                    myAgent.SetDestination(hitInfo.point);
                    anim.SetBool("IsRunning", true);
                }
            }
        }
        else
        {
            myAgent.speed = 0;
            myAgent.enabled = false;
            anim.SetBool("IsRunning", false);
        }
    }
}
