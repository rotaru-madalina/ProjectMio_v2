using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{
    public GameObject[] pages;
    public GameObject pagePrefab;
    public GameObject gridParent;
    public GameObject detailsPanel;


    private IPage[] _pages;
    
    public void TestUnlockPage(IPage page)
    {
        Debug.Log("YAY AM DEBLOCAT PAGINA " + page.Name);
    }

    private void Start()
    {
        _pages = new IPage[pages.Length];
        for (int i = 0; i < pages.Length; i++)        
            _pages[i] = pages[i].GetComponent<IPage>();

        for (int i = 0; i < _pages.Length; i++)
        {
            GameObject newPage = Instantiate(pagePrefab, gridParent.transform);

            Page pageComponent = newPage.GetComponent<Page>();

            pageComponent.SetDescription(_pages[i].Description);
            pageComponent.SetTitle(_pages[i].Name);
            pageComponent.SetImage(_pages[i].Picture);
            pageComponent.SetDescriptionPanel(detailsPanel);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            bool currentActiveStatus = gridParent.transform.parent.gameObject.activeInHierarchy;
            gridParent.transform.parent.gameObject.SetActive(!currentActiveStatus);
            Cursor.lockState = currentActiveStatus?CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !currentActiveStatus; 
        }
    }
}
