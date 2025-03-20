using System.Security.Cryptography;
using UnityEngine;

public class MouseUnlocker : MonoBehaviour
{
    void Start()
    {
        UnlockMouse();
    }
    void Update()
    {
        UnlockMouse();
    }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
