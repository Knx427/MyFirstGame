using System;
using UnityEngine;
using UnityEngine.UI;

public class FirstPersonCam : MonoBehaviour
{
    public Slider slider;
    public Transform orientation;
    public float sensXY = 100f;
    float xRotation;
    float yRotation;
    void Start()
    {
        sensXY = PlayerPrefs.GetFloat("currentSensitivity", 100);
        slider.value = sensXY/10;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        PlayerPrefs.SetFloat("currentSensitivity", sensXY);
        float mouseX = Input.GetAxis("Mouse X")*Time.deltaTime * sensXY;
        float mouseY = Input.GetAxis("Mouse Y")*Time.deltaTime * sensXY;
        
        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Math.Clamp(xRotation,-90f,90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
    public void AdjustSens(float newSens)
    {
        sensXY = newSens * 10;
    }
}
