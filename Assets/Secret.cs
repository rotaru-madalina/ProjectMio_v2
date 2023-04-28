using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Secret : MonoBehaviour , IPage
{
    public Sprite pageImage;
    public string name = "Unnamed";
    public string description = "Lorem ipsum";

    public string Name => name;

    public string Description => description;

    public Sprite Picture => pageImage;

    public void Unlock()
    {
        FindObjectOfType<PageManager>().TestUnlockPage(this);
    }




}
