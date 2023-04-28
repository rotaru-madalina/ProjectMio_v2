using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class TurtleScript : MonoBehaviour
{
    public Transform player;

    public SpeechCollection cancelSpeech;
    public Speech speech;
    private Vector3 destination;
    NavMeshAgent agent;
    Animator animator;
    private bool followingPlayer = true;


    public float closeDist = 3;
    public float farDist = 7;

    private bool wake = false;

    private Vector3 ClosestSecret
    {
        get
        {
            float minDistance = float.PositiveInfinity;
            Vector3 closestTurtlePoint = Vector3.zero;
            for (int i = 0; i < turtlePoints.Count; i++)
            {
                Vector3 turtlePoint = turtlePoints[i];
                float distanceToTurtlePoint = Vector3.Distance(turtlePoint, player.position);
                if (distanceToTurtlePoint < minDistance)
                {
                    minDistance = distanceToTurtlePoint;
                    closestTurtlePoint = turtlePoint;
                }
            }
            return closestTurtlePoint;
        }
    }

    private List<Vector3> turtlePoints = new List<Vector3>();

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
    private float DistanceToPlayer
    {
        get => Vector3.Distance(player.position, transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        foreach(GameObject turtlePoint in GameObject.FindGameObjectsWithTag("TurtlePoint"))
        {
            turtlePoints.Add(turtlePoint.transform.position);
        }
    }

    public void RemoveTurtlePoint(GameObject turtlePoint)
    {
        if(turtlePoints.Contains(turtlePoint.transform.position))
            turtlePoints.Remove(turtlePoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!wake) return;
        animator.SetFloat("inputMagnitude", agent.velocity.magnitude);
        DecideMovement();
    }

    private void DecideMovement()
    {
        if(DistanceToPlayer < closeDist && DistanceToPlayer > 0)
        {
            GoToSecret();
        }
        else if(DistanceToPlayer >= closeDist && DistanceToPlayer <= farDist)
        {
            Stop();
        }
        else
        {
            GoToPlayer();
        }
    }

    private void GoToPlayer()
    {
        Destination = player.position;

        if (!speech.IsActive())
            speech.SetSpeechList(cancelSpeech);

    }

    private void GoToSecret()
    {
        Destination = ClosestSecret;
    }

    public void WakeUp()
    {
        wake = true;
        animator.SetBool ("hide", false);

    }
    private void Stop()
    {
        Destination = this.transform.position;
    }
}
