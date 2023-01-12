using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    float timer;
    public float attackRange = 2;
    public float chaseRange = 10;
    public float speed = 4;
    public float defaultSpeed = 1;
    Transform player;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        animator.speed = defaultSpeed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer >= 5)
            animator.SetBool("isPatrol", true);
        timer += Time.deltaTime;
        float distanse = Vector3.Distance(animator.transform.position, player.position);

        if (distanse < chaseRange)
            animator.SetBool("isChasing", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
