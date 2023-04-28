using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speech : MonoBehaviour
{
    public SpeechCollection speechList;
    public TextMeshProUGUI textMeshPro;

    public float autoNextLineTime = 4f;

    private float currentNextLineCooldown = 0f;


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

    }

    // Update is called once per frame
    void Update()
    {
        currentNextLineCooldown += Time.deltaTime;


        if (currentNextLineCooldown >=  autoNextLineTime)
        {
            currentNextLineCooldown = 0;
            NextLine();
        }



        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            NextLine();
        }

    }
    public void Init() 
    {
        UpdateTextBubble();
    }

    public void NextLine()
    {
        currentLine++;
        textMeshPro.transform.parent.gameObject.SetActive(true);

        /*if (currentSpeech < speechList.Count && currentLine >= speechList[currentSpeech].subspeechList.Count)
        {
            NextSpeech();
        }        
        else*/
        UpdateTextBubble();


    }

    public bool IsActive() => textMeshPro.transform.parent.gameObject.activeInHierarchy;

    public void NextSpeech()
    {
        currentNextLineCooldown = 0;
        textMeshPro.transform.parent.gameObject.SetActive(true);

        currentSpeech++;
        currentLine = 0;

        UpdateTextBubble();

    }

    public void SetSpeechList(SpeechCollection newSpeechList)
    {
        if (speechList == newSpeechList) return;
        currentNextLineCooldown = 0;
        speechList = newSpeechList;
        currentLine = 0;
        currentSpeech = 0;
        textMeshPro.transform.parent.gameObject.SetActive(true);
        UpdateTextBubble();
    }
    private void UpdateTextBubble()
    {
        if (currentSpeech < speechList.SubSpeeches.Count && currentLine < speechList.SubSpeeches[currentSpeech].subspeechList.Count)
            textMeshPro.text = speechList.SubSpeeches[currentSpeech].subspeechList[currentLine];
        else
        {
            Debug.Log("You finished your speech bubbles.");
            textMeshPro.transform.parent.gameObject.SetActive(false);
        }

    }
}
