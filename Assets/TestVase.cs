using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestVase : MonoBehaviour , IPage
{
    public Sprite pageImage;
    public string name = "Vase";
    public string description = "Vase lungi";

    public string Name => name;

    public string Description => description;

    public Sprite Picture => pageImage;

    public void Unlock()
    {
        FindObjectOfType<PageManager>().TestUnlockPage(this);
    }




}
