using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    List<Transform> points = new();
    NavMeshAgent agent;
    Transform player;
    float timer;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform pointsObject = GameObject.FindGameObjectWithTag("PointPatrol").transform;
        foreach (Transform t in pointsObject)
            points.Add(t);
        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[Random.Range(0, points.Count)].position);

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            animator.SetBool("isPatrol", false);
            timer += Time.fixedDeltaTime;
            if (timer >= animator.GetFloat("timerState"))
            {
                timer = 0;
                animator.SetBool("isPatrol", true);
                agent.SetDestination(points[Random.Range(0, points.Count)].position);
            }
        }
            
        float distanse = Vector3.Distance(animator.transform.position, player.position);

        if (distanse < animator.GetFloat("chaseRange"))
            animator.SetBool("isChasing", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
