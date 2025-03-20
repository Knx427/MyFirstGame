using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    TMPro.TMP_Text Text;
    public CountdownTimer CountdownTimer;

    void OnEnable() =>  CalledEnamble();
    void CalledEnamble()
    {
        CountdownTimer.GOtimeUp += GameOverLoader;
    }
    public void GameOverLoader()
    {
        if(CountdownTimer.totalTime <= -5 )
        {
            Debug.Log("Game Over man");
            SceneManager.LoadScene("GameOverScene");
            
        }
    }

}
