using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventInteractionable : MonoBehaviour
{
    public UnityEvent onInteractStart;
    public UnityEvent onInteractEnd;
    public GameObject pressFToInteract;


    public bool hasEnd = false;

    private bool _isPressed = false;

    public bool CanInteract()
    {
        if (_isPressed && !hasEnd)
            return false;
        return true;
    }



    public void RotateText(GameObject target)
    {
        pressFToInteract.transform.LookAt(target.transform);
        pressFToInteract.transform.Rotate(Vector3.up, 180f);
    }

    public void OnInteract()
    {
        if (!CanInteract()) return;

        if (!_isPressed)
            onInteractStart.Invoke();
        else
            onInteractEnd.Invoke();

        _isPressed = !_isPressed;
    }


}
