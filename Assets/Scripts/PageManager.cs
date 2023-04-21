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


    private Dictionary<IPage, Page> dictionar = new Dictionary<IPage, Page>();
    private Transform gridLayoutTransform;

    private IPage[] _pages;
    
    public void TestUnlockPage(IPage page)
    {
        Debug.Log("YAY AM DEBLOCAT PAGINA " + page.Name);

        dictionar[page].SetDescription(page.Description);
        dictionar[page].SetTitle(page.Name);
        dictionar[page].SetImage(page.Picture);
        dictionar[page].SetDescriptionPanel(detailsPanel);
    }



    private void Start()
    {
        _pages = new IPage[pages.Length];
        for (int i = 0; i < pages.Length; i++)        
            _pages[i] = pages[i].GetComponent<IPage>();

        gridLayoutTransform = gridParent.GetComponentInChildren<GridLayoutGroup>().transform;

        for (int i = 0; i < _pages.Length; i++)
        {
            GameObject newPage = Instantiate(pagePrefab, gridLayoutTransform);
            Page pageComponent = newPage.GetComponent<Page>();
            dictionar[_pages[i]] = pageComponent;
            pageComponent.SetDescription("Locked");
            //set image to question mark/lock
        }
    }

    

    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            bool currentActiveStatus = gridParent.activeInHierarchy;
            gridParent.SetActive(!currentActiveStatus);
            Cursor.lockState = currentActiveStatus?CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !currentActiveStatus; 
        }
    }
}
