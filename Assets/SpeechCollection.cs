using UnityEngine;
using System.Collections.Generic;
using static Speech;

[CreateAssetMenu(fileName = "SpeechCollection", menuName = "SpeechCollection", order = 1)]
public class SpeechCollection : ScriptableObject
{
    [SerializeField]
    private List<SubSpeech> subSpeeches = new List<SubSpeech>();

    public List<SubSpeech> SubSpeeches { get => subSpeeches; }
}
