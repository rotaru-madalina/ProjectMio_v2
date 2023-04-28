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
    public GameObject targetGameObject;

    private void OnTriggerEnter(Collider other)
    {
        if((!string.IsNullOrEmpty(targetTag) && other.CompareTag(targetTag) ) ||
            (targetGameObject != null && other.gameObject == targetGameObject))
        {
            //speech.NextSpeech();
            unityEvent.Invoke();
            //Destroy(this.gameObject);
        }
    }
}
