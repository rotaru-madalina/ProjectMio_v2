using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speech : MonoBehaviour
{
    public List<SubSpeech> speechList = new List<SubSpeech>();
    public TextMeshProUGUI textMeshPro;

    private int currentLine;
    private int currentSpeech;

    [System.Serializable] public class SubSpeech
    {
        public List<string> subspeechList = new List<string>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();

        InvokeRepeating("NextLine", 5.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) 
        {
            NextLine();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            NextSpeech();
        }

    }
    public void Init() 
    {
        UpdateTextBubble();
    }

    public void NextLine()
    {
        currentLine++;  
        /*if (currentSpeech < speechList.Count && currentLine >= speechList[currentSpeech].subspeechList.Count)
        {
            NextSpeech();
        }        
        else*/
            UpdateTextBubble();


    }
    public void NextSpeech()
    {
        currentSpeech++;
        currentLine = 0;

        UpdateTextBubble();
    }

    private void UpdateTextBubble()
    {
        if (currentSpeech < speechList.Count && currentLine < speechList[currentSpeech].subspeechList.Count)
            textMeshPro.text = speechList[currentSpeech].subspeechList[currentLine];
        else
            Debug.Log("You finished your speech bubbles.");

    }
}
