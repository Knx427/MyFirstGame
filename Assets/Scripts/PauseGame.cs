using UnityEngine;
using System;

public class PauseGame : MonoBehaviour
{
    [Header("Keybinds")]
    [SerializeField]
    public KeyCode pauseGame = KeyCode.Escape;
    public bool gamePaused; 
    public Canvas CanvasObject;
    public Canvas SettingsCanvas;
    public static event Action settingsClosed;

    private void Start()
    {
        gamePaused=false;
    }
    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePaused = !gamePaused;
            paused();
        }
    }
    public void Resume()
    {
        CanvasObject.GetComponent<Canvas>().enabled = false;
            Time.timeScale = 1;
            LockMouse();
    }

    void paused()
    {
        if(gamePaused)
        {
            CanvasObject.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0f;
            UnlockMouse();
        }
        else 
        {
            CanvasObject.GetComponent<Canvas>().enabled = false;
            if(SettingsCanvas.GetComponent<Canvas>().enabled == true)
            {
                SettingsCanvas.GetComponent<Canvas>().enabled = false;
                settingsClosed?.Invoke();
            }
            Time.timeScale = 1;
            LockMouse();
        }
    }
    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
