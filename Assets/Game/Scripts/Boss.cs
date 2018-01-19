using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public float followDistance = 15f;

    GameObject player;
    NavMeshAgent agent;
    Animator anim;

    private void Start()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(agent.velocity == Vector3.zero)
            anim.SetBool("IsWalking", false);
        else
            anim.SetBool("IsWalking", true);

        if(distance > followDistance)
            agent.SetDestination(player.transform.position);
        else
            agent.SetDestination(transform.position);
    }
}
