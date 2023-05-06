using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChildCounter : MonoBehaviour
{
    public int target = 0;

    int count = 0;
    public UnityEvent onTargetReached;

    private void Start()
    {
        count = transform.childCount;
    }

    public void RemoveCount()
    {
        count--;
        CheckTarget();
    }

    private void CheckTarget()
    {
        if (count == target)
            onTargetReached.Invoke();
    }

    public void AddCount()
    {
        count++;
        CheckTarget();
    }


}
