using System;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour
{
    public Slider slider;
    public AudioSource Volume;

     void Start()
    {
        slider.value = Volume.volume;
    } 
    public void AdjustVol(float newVol)
    {
        Volume.volume = newVol;
    }
}
