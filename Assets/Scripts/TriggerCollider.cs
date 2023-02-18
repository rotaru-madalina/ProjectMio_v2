using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCollider : MonoBehaviour
{
    //public Speech speech;
    public UnityEvent unityEvent;
    public string targetTag;

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag(targetTag))
        {
            //speech.NextSpeech();
            unityEvent.Invoke();
            //Destroy(this.gameObject);
        }
    }
}
