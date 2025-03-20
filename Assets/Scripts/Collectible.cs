using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static event Action onCollected;
    public AudioSource audioData;
    public static int total;
    void Awake() => total++;
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
            onCollected?.Invoke();
            Destroy(gameObject);
        }
    }
    void Reset()
    {
        total=0;
    }
}
