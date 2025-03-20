using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ResetGame : MonoBehaviour
{
    public static event Action Reseted;
    public void Reset()
    {
        SceneManager.LoadScene("asd 1.0");
        Reseted?.Invoke();
        Time.timeScale = 1;
    }
}
