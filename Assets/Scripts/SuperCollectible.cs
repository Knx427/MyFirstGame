using UnityEngine;
using System;
public class SuperCollectible : MonoBehaviour
{
    public static event Action Collected;
    public AudioSource audioData;
    public static int Stotal;
    
    void Awake() => Stotal++;
    void OnEnable() =>  Enabler();

    void Enabler()
    {
        ResetGame.Reseted += Reset;
        Play.resetScore += Reset;
        MainMenu.resetScore += Reset;
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioData.Play(0);
            Collected?.Invoke();
            Destroy(gameObject);
        }
    }

    void Reset()
    {
        Stotal=0;
    }
}
