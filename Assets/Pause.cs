using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool _isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_isPaused)
                BeginPause();
            else
            {
                LockCursor();
                EndPause();
            }
        }
    }

    public void EndPause()
    {
        FindObjectOfType<CinemachineFreeLook>().enabled = true;
        Time.timeScale = 1;
        pauseMenu.SetActive(_isPaused = false);
    }

    public static void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void BeginPause()
    {
        FindObjectOfType<CinemachineFreeLook>().enabled = false;
        UnlockCursor();
        Time.timeScale = 0;
        pauseMenu.SetActive(_isPaused = true);
    }

    private static void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
