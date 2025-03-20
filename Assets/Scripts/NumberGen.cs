using UnityEngine;
using System;

public class NumberGen : MonoBehaviour, IInteractable
{
    public static event Action Interacted;
    int count;
    public AudioSource audioData;
    public void Interact()
    {
        audioData.Play(0);
        count++;
        Debug.Log((0,100,count));
        Interacted?.Invoke();
    }
}
