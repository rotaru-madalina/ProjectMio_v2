using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{
    public Image Image;
    private string description;
    private string pageName;

    private GameObject descriptionPanel;

    public void SetDescription(string text)
    {
        description = text;
    }

    public void SetDescriptionPanel(GameObject gameObject)
    {
        descriptionPanel = gameObject;
    }

    public void SetTitle(string text)
    {
        pageName = text;
    }

    public void SetImage(Sprite image)
    {
        Image.sprite = image;
    }

    public void OpenDescriptionPanel()
    {
        var details = transform.parent.parent.GetComponentInChildren<DetailsPanel>();

        details.text.text = description;
        details.image.sprite = Image.sprite;

        /*
        Image[] childImages = descriptionPanel.transform.parent.GetComponentsInChildren<Image>(false);
        foreach (Image childImage in childImages)
        {
            if (childImage.transform != descriptionPanel.transform)
            {
                childImage.sprite = Image.sprite;
                break;
            }
        }
        descriptionPanel.GetComponentInChildren<TMP_Text>().text = description;
        */
    }
}
