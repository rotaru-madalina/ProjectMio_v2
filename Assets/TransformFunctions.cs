using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFunctions : MonoBehaviour
{

    public void Dissapear(float dissapearSpeed)
    {
        StartCoroutine(DissapearRoutine(dissapearSpeed));
    }
    
    public IEnumerator DissapearRoutine(float dissapearSpeed)
    {
        // Scala initiala. (Probabil (1,1,1)
        Vector3 initialScale = transform.localScale; 

        while(transform.localScale.magnitude > 0.1f)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * dissapearSpeed);
            yield return null;
        }

        transform.localScale = Vector3.zero;
    }




}
