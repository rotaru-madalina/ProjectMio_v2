using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendScript : MonoBehaviour
{
    public Transform player;
    public float distanceToPlayer = 1f;
    public bool startDisabled = false;


    private Vector3 destination;
    NavMeshAgent agent;
    Animator animator;
    private bool followingPlayer = true;

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

    private bool _started = false;

    public void GoToPoint(Transform destination)
    {
        Destination = destination.position;
        followingPlayer = false;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        _started = !startDisabled;
    }

    public void Enable() => _started = true; 
    public void Disable() => _started = false;

    private void Update()
    {
        if (!_started) return;
        if(followingPlayer)
        {
            GoToPlayer();
        }
        animator.SetFloat("inputMagnitude", agent.velocity.magnitude);
    }

    private void GoToPlayer()
    {
        Vector3 playerpos = player.position;
        Vector3 position = transform.position;

        Vector3 dirPlayerToMe = (position - playerpos).normalized;

        Destination = playerpos + (dirPlayerToMe) * distanceToPlayer;

    }
}
