using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public static event Action resetScore;
    public void PlayScene()
    {
        SceneManager.LoadScene("asd 1.0");
        resetScore?.Invoke();
        Time.timeScale = 1;
    }
}
