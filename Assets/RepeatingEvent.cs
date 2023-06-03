using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RepeatingEvent : MonoBehaviour
{
    public UnityEvent repeatedEvent;

    public float startDelay = 2f;
    public float repeatRate = 10f;

    private void FireEvent()
    {
        repeatedEvent.Invoke();
    }

    private void Start()
    {
        InvokeRepeating("FireEvent",startDelay,repeatRate);
    }
}
