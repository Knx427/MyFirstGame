using UnityEngine;
using TMPro;
using System;

public class CountdownTimer : MonoBehaviour
{
    public static event Action timeUp;
    public static event Action GOtimeUp;
   // public GameObject FloatingAddTime;
   // public GameObject FloatingParent;
    public Transform spawnLocation; 
   // GameObject Clone;
    public float totalTime = 90; // Set the total time for the countdown
    public TextMeshProUGUI timerText; // Use TextMeshProUGUI instead of Text

    void Update()
    {
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;

            float minutes = Mathf.FloorToInt(totalTime / 60);
            float seconds = Mathf.FloorToInt(totalTime % 60);

            timerText.text = string.Format("Time Left: {0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            timerText.text = "Time's up";
            timeUp?.Invoke();
            GameOverTimer();
        }
    }
    void GameOverTimer()
    {
        if(totalTime > -5)
        {
            totalTime -= Time.deltaTime;
            Debug.Log("-Seconder");
        }
        else if(totalTime <=-5)
        {
            GOtimeUp?.Invoke();
        }
    }
    void OnEnable() => Enabler();
    void OnDisable() => Disabler();

    void Enabler()
    {
        Collectible.onCollected += addTimeColl;
        SuperCollectible.Collected += addSuperTimeColl;
        ResetGame.Reseted += Reseter;
        Play.resetScore += Reseter;
        MainMenu.resetScore += Reseter;
        
    }

    void Disabler()
    {
        Collectible.onCollected -= addTimeColl;
        SuperCollectible.Collected -= addSuperTimeColl;
    }

    void addTimeColl()
    {
        if(totalTime>0)
        totalTime += 0.5f;
          //  Clone.transform.parent = transform;
          //  Clone = Instantiate(FloatingAddTime, FloatingParent.transform);
          //  Destroy(Clone, 1f);
    }
    
    void addSuperTimeColl()
    {
        if(totalTime>0)
        totalTime += 1.5f;
          //  Instantiate(FloatingAddTime, transform.position, Quaternion.identity);
          // AddTime.transform.GetChild(0).GetComponent<TextMeshPro>().text = "+1.5s";
    }

    void Reseter()
    {
        totalTime = 90;
    }
}
