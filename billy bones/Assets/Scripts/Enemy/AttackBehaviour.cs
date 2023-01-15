using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackBehaviour : StateMachineBehaviour
{
    Transform player;
    GameObject gameOver;
    NavMeshAgent agent;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.transform.LookAt(player);
        float distanse = Vector3.Distance(animator.transform.position, player.position);
        if (distanse > animator.GetFloat("attackRange"))
            animator.SetBool("isAttacking", false);
        if (agent.remainingDistance <= agent.stoppingDistance)
            PlayerDeathRes.gameOver.Death();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
