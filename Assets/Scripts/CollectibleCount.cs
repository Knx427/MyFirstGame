using System.Security.Cryptography;
using Unity.VisualScripting.Antlr3.Runtime;
using System;
using UnityEngine;
using Unity.VisualScripting;

public class CollectibleCount : MonoBehaviour
{
    TMPro.TMP_Text Text;
    int count;
    public static event Action allCollected;
    public CountdownTimer CountdownTimer;
    void Start() => UpdateCount();
    void Awake()
    {
        Text = GetComponent<TMPro.TMP_Text>();
    }
    void OnEnable() => Enabler();

    void Enabler()
    {
        Collectible.onCollected += OnCollectibleCollected;
        SuperCollectible.Collected += OnSuperCollectibleCollected;
        CountdownTimer.timeUp += collTooLate;
    }
    void OnDisable() => Disabler();

    void Disabler()
    {
        Collectible.onCollected -= OnCollectibleCollected;
        SuperCollectible.Collected -= OnSuperCollectibleCollected;
    }

    void OnCollectibleCollected()
    {
       count++;
       UpdateCount();
    }
    void OnSuperCollectibleCollected()
    {
        count++;
        UpdateCount();
    }

    void UpdateCount()
    {
        int TotalCollectibles = SuperCollectible.Stotal + Collectible.total;
        Text.text = $"Collect Crystals and escape before the timer runs out!<br>Crystals: {count}/{TotalCollectibles}";
        if(count==TotalCollectibles && CountdownTimer.totalTime > 0 )
            Exec();
    }

    void Exec()
    {   
        {Text.text = $"You have all the Crystals now hurry find the exit!";}
        {allCollected?.Invoke();}

    }
    void collTooLate()
    {
        int TotalCollectibles = SuperCollectible.Stotal + Collectible.total;
        if(count==TotalCollectibles && CountdownTimer.totalTime < 0 ) //Message if collected the gems too late
            {Text.text = $"You got all Crystals but too late";}
        else if(count!=TotalCollectibles && CountdownTimer.totalTime < 0)
            {Text.text = $"You were too late";}
    }
}
