using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public static event Action resetScore;
    public void MainScene()
    {
        SceneManager.LoadScene("MainMenuScene");
        resetScore?.Invoke();
    }
}
