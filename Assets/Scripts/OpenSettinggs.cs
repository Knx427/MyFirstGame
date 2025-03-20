using Unity.VisualScripting;
using UnityEngine;

public class OpenSettinggs : MonoBehaviour
{
    public bool SettingsOpen; 
    public Canvas CanvasObject;
    void Start()
    {
        SettingsOpen=false;
    }
    void Update()
    {
        if(SettingsOpen==true)
            UnlockMouse();
    }
    void OnEnable() => PauseGame.settingsClosed += CloseSettings; 
    void OnDisable() => PauseGame.settingsClosed -= CloseSettings; 

    public void OpenSettings()
    {
        if(!SettingsOpen)
        {
            CanvasObject.GetComponent<Canvas>().enabled = true;
            SettingsOpen = true;
            UnlockMouse();
        }
        else if(SettingsOpen)
        {
            CanvasObject.GetComponent<Canvas>().enabled = false;
            SettingsOpen = false;
        }
    }
    public void CloseSettings()
    {
        if(SettingsOpen)
        {
            CanvasObject.GetComponent<Canvas>().enabled = false;
            SettingsOpen = false;
        }
    }
    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
