using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendScript : MonoBehaviour
{
    public Transform player;
    public float distanceToPlayer = 1f;

    private Vector3 destination;
    NavMeshAgent agent;
    Animator animator;
    public Vector3 Destination 
    {
        get
        { 
            return destination; 
        }

        set
        { 
            destination = value;
            agent.destination = Destination;
            
        }
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        Vector3 playerpos = player.position;
        Vector3 position = transform.position;

        Vector3 dirPlayerToMe = (position - playerpos).normalized;
        
        Destination = playerpos + (dirPlayerToMe) * distanceToPlayer;

        animator.SetFloat("inputMagnitude", agent.velocity.magnitude);
    }
}
